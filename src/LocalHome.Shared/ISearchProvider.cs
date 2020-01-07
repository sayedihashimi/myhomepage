namespace LocalHome.Shared {
    public interface ISearchProvider {
        string DisplayName { get; set; }
        string SearchUrl { get; set; }
        string ImageUrl { get; set; }
        string BackgroundColor { get; set; }
    }
}