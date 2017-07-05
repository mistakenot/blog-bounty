using System.Linq;
using System.Threading.Tasks;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;
using Microsoft.AspNetCore.Mvc;
using BlogBounty.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TopicController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewTopicRequest request)
        {
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
    }
}