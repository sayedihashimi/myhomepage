using System;
namespace LocalHome.Shared {
    public class SearchProvider : ISearchProvider {

        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public string ImageUrl { get; set; }
        public string BackgroundColor { get; set; }
    }
}
