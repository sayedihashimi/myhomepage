using System;
using System.Collections.Generic;
using System.IO;
using LocalHome.Shared;
using LocalHome.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;

namespace LocalHome.Pages {
    public class IndexBase : ComponentBase {
        [Inject]
        public IWebHostEnvironment WebHostEnv { get; set; }
        [Inject]
        public IUserLinkJsonReader UserLinkReader { get; set; }

        public List<UserLink> GetUserLinks() {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            return UserLinkReader.GetUserLinksFromFile(filepath);
        }

        public List<UserLinkViewModel> GetUserLinkViewModels() {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            List<UserLink>links = UserLinkReader.GetUserLinksFromFile(filepath);

            List<UserLinkViewModel> result = new List<UserLinkViewModel>();
            links.ForEach(ul => result.Add(new UserLinkViewModel { UserLink = ul }));
            return result;
        }
    }
}
