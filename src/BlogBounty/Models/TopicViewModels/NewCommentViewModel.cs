using System.ComponentModel.DataAnnotations;

namespace BlogBounty.Models.TopicViewModels
{
    public class NewCommentViewModel
    {
        [Required]
        [MinLength(1)]
        public string Body { get; set; }

        public int? ReplyingTo { get; set; }
    }
}