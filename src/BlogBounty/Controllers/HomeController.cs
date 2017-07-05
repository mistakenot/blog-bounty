using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBounty.Data;
using BlogBounty.Extensions;
using BlogBounty.Models.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var latestTopics = await _db.Topics
                .Include(t => t.Subscriptions)
                .Include(t => t.Tags).ThenInclude(tag => tag.Tag)
                .Include(t => t.User)
                .OrderBy(t => t.CreatedAt)
                .Take(10)
                .ToListAsync();

            var model = new HomeIndexViewModel()
            {
                Topics = latestTopics.Select(t => t.ToViewModel()),
                Page = 1,
                MaxPages = 1
            };

            return View(model);
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
