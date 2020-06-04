using System;
using System.ComponentModel.DataAnnotations;

namespace LocalHome.Shared {
    public class UserLink : IUserLink {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Text is required")]
        public string Text { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Url is required")]
        public string Url { get; set; }
        public bool InvertImageColors { get; set; }
        public string BackgroundColor { get; set; }
    }
}
