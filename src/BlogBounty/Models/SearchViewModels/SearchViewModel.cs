using BlogBounty.Models.TopicViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BlogBounty.Models.SearchViewModels
{
    public class SearchViewModel
    {
        public SearchRequestModel Request { get; set; }

        public IEnumerable<TopicViewModel> Topics { get; set; }

        public SearchViewModel()
        {
            Topics = Enumerable.Empty<TopicViewModel>();
        }
    }
}