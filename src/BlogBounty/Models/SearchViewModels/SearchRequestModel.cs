namespace BlogBounty.Models.SearchViewModels
{
    public class SearchRequestModel
    {
        public string Tag { get; set; }

        public string Filter { get; set; }

        public static readonly SearchRequestModel Default = new SearchRequestModel() {Tag = null, Filter = null};
    }
}