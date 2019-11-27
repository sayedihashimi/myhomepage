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

        protected List<UserLinkViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync() {
            ULinks = await GetUserLinkViewModels();
        }

        protected void DoFilter(ChangeEventArgs args) {
            Console.WriteLine($"inside Index.Razor->DoFilter: {args.Value}");
            string searchText = args.Value as string;

            if (string.IsNullOrWhiteSpace(searchText)) return;

            foreach (var ul in ULinks) {
                ul.Hidden = !IsMatch(ul.UserLink, searchText);
            }
        }

        protected bool IsMatch(UserLink userLink, string searchText) {
            var strtosearch = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return strtosearch.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
