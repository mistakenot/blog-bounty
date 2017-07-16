using BlogBounty.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogBounty.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static IQueryable<TopicEntity> TopicsWithRelations(this ApplicationDbContext db)
        {
            return db
                .Topics
                .Include(t => t.Subscriptions)
                .Include(t => t.Tags).ThenInclude(tag => tag.Tag)
                .Include(t => t.User)
                .Include(t => t.Upvotes);
        }
    }
}