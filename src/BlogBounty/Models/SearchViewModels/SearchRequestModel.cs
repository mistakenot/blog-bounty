namespace BlogBounty.Models.SearchViewModels
{
    public class SearchRequestModel
    {
        public string Tag { get; set; }

        public string Filter { get; set; }

        public int Page { get; set; }

        public SearchRequestModel()
        {
            Tag = null;
            Filter = null;
            Page = 0;
        }
    }
}