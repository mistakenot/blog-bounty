namespace BlogBounty.Models.SearchViewModels
{
    public class SearchRequestModel
    {
        public string Tag { get; set; }

        public string Filter { get; set; }

        public SearchRequestModel()
        {
            Tag = null;
            Filter = null;
        }
    }
}