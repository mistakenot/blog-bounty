using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBounty.Data;
using BlogBounty.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBounty.ViewComponents
{
    public class TopicSearchViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public TopicSearchViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int skip = 0,
            int take = 10,
            IEnumerable<string> tags = null)
        {
            var topics = await _db
                .Topics
                .Include(t => t.Subscriptions)
                .Include(t => t.Tags).ThenInclude(tag => tag.Tag)
                .Include(t => t.User)
                .Include(t => t.Upvotes)
                .Where(t =>
                    tags == null || t.Tags.Any(tag => tags.Contains(tag.Tag.Label)))
                .OrderByDescending(t => t.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var models = topics.Select(t => t.ToViewModel());

            return View(models);
        }
    }
}
