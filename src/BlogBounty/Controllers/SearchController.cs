using BlogBounty.Models.SearchViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogBounty.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Index(SearchRequestModel.Default);
        }

        [HttpPost]
        public IActionResult Index(
            SearchRequestModel model)
        {
            return View(model);
        }
    }
}