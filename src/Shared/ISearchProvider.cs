namespace LocalHome.Shared {
    public interface ISearchProvider {
        string DisplayName { get; set; }
        string SearchUrl { get; set; }
        bool IsDefault { get; set; }
    }
}