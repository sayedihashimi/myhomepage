using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        public IUserLinkJsonReader UlReader { get; set; }

        public async Task<List<UserLink>> GetUserLinks() {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            return await UlReader.GetUserLinksFromFileAsync(filepath);
        }

        public async Task<List<UserLinkViewModel>> GetUserLinkViewModels() {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "sayedha.json");
            List<UserLink>links = await UlReader.GetUserLinksFromFileAsync(filepath);
            
            List<UserLinkViewModel> result = new List<UserLinkViewModel>();
            links.ForEach(ul => result.Add(new UserLinkViewModel { UserLink = ul }));
            return result;
        }
    }
}
