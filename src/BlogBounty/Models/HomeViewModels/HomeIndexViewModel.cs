using BlogBounty.Models.SearchViewModels;

namespace BlogBounty.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public SearchViewModel SearchModel { get; set; }

        public HomeIndexViewModel()
        {
            SearchModel = new SearchViewModel();
        }
    }
}