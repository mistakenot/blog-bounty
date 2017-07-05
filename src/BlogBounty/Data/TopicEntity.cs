using BlogBounty.Models;

namespace BlogBounty.Data
{
    public class TopicEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}