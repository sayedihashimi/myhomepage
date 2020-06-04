using LocalHome.Client.ViewModels;
using LocalHome.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LocalHome.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        public IUserLinkJsonReader UlReader { get; set; }

        protected List<UserLinkViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ULinks = await GetUserLinkViewModels(null);
        }

        public async Task<List<UserLink>> GetUserLinksAsync(string username)
        {
            // TODO: Get this from somewhere
            username = "sayedha";
            List<UserLink> links = await httpClient.GetFromJsonAsync<List<UserLink>>(
                $"api/userlink/{username}");
            // get from webapi request

            return links;
        }
        public async Task<List<UserLinkViewModel>> GetUserLinkViewModels(string username)
        {
            List<UserLink> links = await GetUserLinksAsync(username);

            List<UserLinkViewModel> result = new List<UserLinkViewModel>();
            links.ForEach(ul => result.Add(new UserLinkViewModel { UserLink = ul }));
            return result;
        }
        protected void DoFilter(ChangeEventArgs args)
        {
            Console.WriteLine($"inside Index.Razor->DoFilter: {args.Value}");
            string searchText = args.Value as string;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // make them all visible
                foreach (var ul in ULinks)
                {
                    ul.Hidden = false;
                }
            }
            else
            {
                foreach (var ul in ULinks)
                {
                    ul.Hidden = !IsMatch(ul.UserLink, searchText);
                }
            }

        }

        protected bool IsMatch(UserLink userLink, string searchText)
        {
            var strtosearch = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return strtosearch.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }

}
