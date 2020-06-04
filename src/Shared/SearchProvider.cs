using System;
namespace LocalHome.Shared {
    public class SearchProvider : ISearchProvider {

        public string DisplayName { get; set; }
        public string SearchUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}
