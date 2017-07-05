using BlogBounty.Data;

namespace BlogBounty.Models.SubmissionViewModels
{
    public class NewSubmissionRequestModel
    {
        public string Uri { get; set; }

        public string Title { get; set; }

        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }
    }
}