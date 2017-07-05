using System;
using System.Collections.Generic;
using BlogBounty.Models;
using BlogBounty.Models.TopicViewModels;

namespace BlogBounty.Data
{
    public class TopicEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<SubmissionEntity> Subscriptions { get; set; }
        public List<TopicTagEntity> Tags { get; set; }
        public List<UpvoteEntity> Upvotes { get; set; }

        public TopicEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}