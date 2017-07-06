using System;

namespace BlogBounty.Data
{
    public class CommentEntitiy
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? ParentId { get; set; }
        public CommentEntitiy Parent { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }
    }
}