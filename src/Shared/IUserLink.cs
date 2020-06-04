﻿namespace LocalHome.Shared {
    public interface IUserLink {
        string Text { get; set; }
        string ImageUrl { get; set; }
        string Url { get; set; }
        bool InvertImageColors { get; set; }
        string BackgroundColor { get; set; }
    }
}