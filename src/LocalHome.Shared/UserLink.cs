using System;
using System.ComponentModel.DataAnnotations;

namespace LocalHome.Shared {
    public class UserLink : IUserLink {
        [Required]
        public string Text { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Url { get; set; }
        public bool InvertImageColors { get; set; }
    }
}
