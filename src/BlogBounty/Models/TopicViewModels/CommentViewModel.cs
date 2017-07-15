using System;
using System.Collections.Generic;

namespace BlogBounty.Models.TopicViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }

        public int TopicId { get; set; }

        public List<CommentViewModel> Replies { get; set; } = new List<CommentViewModel>();

        public int? ParentId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}