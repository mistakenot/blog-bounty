using BlogBounty.Models.SearchViewModels;

namespace BlogBounty.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public SearchViewModel SearchModel { get; set; }

        public bool CanReset { get; set; }

        public int? NextPage { get; set; }

        public int? PrevPage { get; set; }

        public HomeIndexViewModel()
        {
            SearchModel = new SearchViewModel();
            CanReset = false;
            NextPage = null;
            PrevPage = null;
        }
    }
}