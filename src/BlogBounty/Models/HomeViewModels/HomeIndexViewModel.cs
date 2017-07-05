using System.Collections.Generic;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;

namespace BlogBounty.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<TopicViewModel> Topics { get; set; }

        public int Page { get; set; }

        public int MaxPages { get; set; }
    }
}