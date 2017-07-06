using System.Collections.Generic;

namespace BlogBounty.Models.TopicViewModels
{
    public class ViewTopicViewModel
    {
        public TopicViewModel Topic { get; set; }

        public bool UserHasVoted { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}