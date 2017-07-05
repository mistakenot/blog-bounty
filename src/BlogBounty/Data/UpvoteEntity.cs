using BlogBounty.Models;

namespace BlogBounty.Data
{
    public class UpvoteEntity
    {
        public int Id { get; set; }

        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}