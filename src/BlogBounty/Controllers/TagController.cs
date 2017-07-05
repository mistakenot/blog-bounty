using System.Linq;
using System.Threading.Tasks;
using BlogBounty.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogBounty.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace BlogBounty.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tags = await _db.Tags.ToListAsync();
            return Ok(tags);
        } 

        [HttpGet]
        public async Task<IActionResult> Suggestions(string term)
        {
            var tags = await _db.Tags
                .Where(t => t.Tag.Matches(term))
                .Select(t => t.Tag)
                .ToListAsync();

            return Ok(tags);
        }
    }
}