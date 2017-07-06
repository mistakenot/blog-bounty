using System.Threading.Tasks;
using BlogBounty.Data;
using BlogBounty.Models.SubmissionViewModels;
using Microsoft.AspNetCore.Mvc;
using BlogBounty.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.Controllers
{
    [Authorize]
    public class SubmissionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public SubmissionController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _db = db;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NewSubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (!await _db.Submissions.AnyAsync(u => u.UserId == user.Id))
                {
                    ModelState.AddModelError(string.Empty, "You have already made a submission for this blog.");
                    return View(model);
                }

                var topic = await _db.Topics
                    .FirstOrDefaultAsync(t => t.Id == model.TopicId);

                if (topic == null)
                {
                    ModelState.AddModelError(string.Empty, "Topic has not been found.");
                    return View(model);
                }
                
                var submission = new SubmissionEntity()
                {
                    Uri = model.Uri,
                    UserId = user.Id,
                    TopicId = topic.Id
                };

                _db.Submissions.Add(submission);
                await _db.SaveChangesAsync();

                var subscriberEmail = topic.User.Email;

                if (subscriberEmail != null)
                {
                    await _emailSender.SendEmailAsync(subscriberEmail, "New blog post",
                        $"Someone has created a new blog post entry for your topic. View it at {submission.Uri}.");
                }
            }

            return View(model);
        }
    }
}