using BlogBounty.Data;
using BlogBounty.Extensions;
using BlogBounty.Models.SearchViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBounty.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Index(new SearchRequestModel());
        }

        [HttpPost]
        public IActionResult Index(
            SearchRequestModel model)
        {
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Suggestion(string filter)
        {
            var suggestions = await _db
                .TopicsWithRelations()
                .Where(t => t.Title.Contains(filter) || t.Description.Contains(filter))
                .Take(5)
                .ToListAsync();
            
            var models = suggestions
                .Select(s => new SearchResponseViewModel { Title = s.Title, Url = Url.Action("View", "Topic", new { Id = s.Id }) })
                .ToList();

            return Json(models);
        }

        [HttpGet]
        public async Task<IActionResult> Tags(string filter)
        {
            var tags = await _db
                .Tags
                .Where(t => t.Label.Contains(filter))
                .ToListAsync();

            var models = tags.Select(t => new SearchTagResponseModel { Value = t.Label });

            return Json(models);
        } 
    }
}