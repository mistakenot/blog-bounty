using System.Linq;
using System.Threading.Tasks;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;
using Microsoft.AspNetCore.Mvc;
using BlogBounty.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TopicController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewTopicRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _userManager.GetUserAsync(User);
            var requestedTags = request.Tags?.Split(' ') ?? new string[0];

            var tags = await _db.Tags
                .Where(t => requestedTags.Contains(t.Tag))
                .ToListAsync();

            var newTags = requestedTags
                .Except(tags.Select(t => t.Tag))
                .Select(t => new TagEntity {Tag = t});

            tags = tags.Concat(newTags).ToList();

            _db.Tags.AddRange(newTags);
            await _db.SaveChangesAsync();

            var model = new TopicEntity
            {
                Title = request.Title,
                Description = request.Description,
                UserId = user.Id
            };

            _db.Add(model);

            var topicTags = tags
                .Select(t => new TopicTagEntity {TagId = t.Id, TopicId = model.Id});

            _db.AddRange(topicTags);
            await _db.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string title, string description)
        {
            var query = _db.Topics.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(q => q.Title.Matches(title));
            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(q => q.Description.Matches(description));
            }

            var results = await query.ToListAsync();

            var model = new TopicSearchResultsModel
            {
                Results = results.Select(r => new TopicSearchResult {Title = r.Title, TopicId = r.Id})
            };

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> View([FromRoute]int id)
        {
            var topic = await _db.Topics
                .Include(t => t.Subscriptions)
                .Include(t => t.User)
                .Include(t => t.Tags)
                .ThenInclude(t => t.Tag)
                .Include(t => t.Upvotes)
                .SingleOrDefaultAsync(t => t.Id == id);

            if (topic == null)
            {
                ModelState.AddModelError(string.Empty, "Not found.");
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            var userHasVoted = await _db.Upvotes
                .AnyAsync(u => u.TopicId == id && u.UserId == user.Id);

            var model = new ViewTopicViewModel
            {
                Topic = topic.ToViewModel(),
                UserHasVoted = userHasVoted
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int id, bool userHasVoted)
        {
            if (!await _db.Topics.AnyAsync(t => t.Id == id))
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            if (userHasVoted)
            {
                var upvote = await _db.Upvotes
                    .FirstOrDefaultAsync(u => u.TopicId == id && u.UserId == user.Id);

                if (upvote == null)
                {
                    ModelState.AddModelError(string.Empty, "You have not voted on this topic.");
                }
                else
                {
                    _db.Remove(upvote);
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                if (await _db.Upvotes.AnyAsync(u => u.TopicId == id && u.UserId == user.Id))
                {
                    ModelState.AddModelError(string.Empty, "You have already voted.");
                }
                else
                {
                    var upvote = new UpvoteEntity()
                    {
                        TopicId = id,
                        UserId = user.Id
                    };

                    _db.Add(upvote);
                    await _db.SaveChangesAsync();
                }
            }

            return RedirectToAction("View", new {id});
        }
    }
}