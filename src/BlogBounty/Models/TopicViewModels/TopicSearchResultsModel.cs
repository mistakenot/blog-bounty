using System.Collections.Generic;

namespace BlogBounty.Models.TopicViewModels
{
    public class TopicSearchResultsModel
    {
        public IEnumerable<TopicSearchResult> Results { get; set; }
    }

    public class TopicSearchResult
    {
        public string Title { get; set; }

        public int TopicId { get; set; }
    }
}