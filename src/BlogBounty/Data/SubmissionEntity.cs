using BlogBounty.Models;

namespace BlogBounty.Data
{
    public class SubmissionEntity
    {
        public int Id { get; set; }

        public string Uri { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }
    }
}