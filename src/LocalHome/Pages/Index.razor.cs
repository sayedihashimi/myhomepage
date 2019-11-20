using System;
using System.Collections.Generic;
using System.IO;
using LocalHome.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
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
    }
}
