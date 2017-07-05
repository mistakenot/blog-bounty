using System.ComponentModel.DataAnnotations;

namespace BlogBounty.Models.TopicViewModels
{
    public class NewTopicRequest
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }
    }
}