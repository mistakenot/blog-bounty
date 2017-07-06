using System.Linq;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;

namespace BlogBounty.Extensions
{
    public static class EntityExtensions
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
                Tags = t.Tags.Select(tt => tt.Tag.Label).ToArray(),
                Creator = t.User.UserName,
                CreatedAt = t.CreatedAt
            };
        }

        public static CommentViewModel ToViewModel(this CommentEntitiy c)
        {
            return new CommentViewModel
            {
                Id = c.Id,
                Body = c.Body,
                UserName = c.User.UserName
            };
        }
    }
}