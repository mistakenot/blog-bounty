using System.Linq;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;

namespace BlogBounty.Extensions
{
    public static class TopicEntityExtensions
    {
        public static TopicViewModel ToViewModel(this TopicEntity t)
        {
            return new TopicViewModel
            {
                Description = t.Description,
                Id = t.Id,
                NumberOfSubscriptions = t.Subscriptions.Count,
                NumberOfUpvotes = t.Upvotes.Count,
                Title = t.Title,
                Tags = t.Tags.Select(tt => tt.Tag.Tag).ToArray(),
                Creator = t.User.UserName,
                CreatedAt = t.CreatedAt
            };
        }
    }
}