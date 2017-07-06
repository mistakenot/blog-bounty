using System;

namespace BlogBounty.Models.TopicViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int NumberOfSubscriptions { get; set; }

        public string[] Tags { get; set; } = new string[0];

        public string Creator { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public bool UserHasVoted { get; set; }

        public int NumberOfUpvotes { get; set; }
    }
}