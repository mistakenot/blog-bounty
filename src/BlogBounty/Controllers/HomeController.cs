using System.Threading.Tasks;
using BlogBounty.Data;
using Microsoft.AspNetCore.Mvc;
using BlogBounty.Models.SearchViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlogBounty.Extensions;
using BlogBounty.Models.HomeViewModels;

namespace BlogBounty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public Task<IActionResult> Index(string filter)
        {
            return Index(new SearchRequestModel { Filter = filter });
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]SearchRequestModel model)
        {
            var tags = model.Tag?.Split(' ');
            var take = 10;
            var skip = take * model.Page;

            var query = _db
                .TopicsWithRelations()
                .Where(t =>
                    tags == null || t.Tags.Any(tag => tags.Contains(tag.Tag.Label)))
                .Where(t =>
                    string.IsNullOrEmpty(model.Filter)
                    || (t.Title.Contains(model.Filter) || (t.Description ?? string.Empty).Contains(model.Filter) || t.Tags.Any(tag => tag.Tag.Label.Contains(model.Filter))))
                .OrderByDescending(t => t.CreatedAt)
                .Skip(skip);

            var anyMore = await query
                .Skip(take)
                .AnyAsync();

            var topics = await query
                .Take(take)
                .ToListAsync();

            var response = new HomeIndexViewModel
            {
                SearchModel = new SearchViewModel
                {
                    Request = model,
                    Topics = topics.Select(t => t.ToViewModel())
                },
                CanReset = tags != null || model.Filter != null,
                PrevPage = model.Page > 0 ? (int?)model.Page - 1 : null,
                NextPage = anyMore ? (int?)model.Page + 1 : null
            };

            return View(response);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
