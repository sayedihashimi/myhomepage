using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocalHome.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalHome.Server.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{username?}")]
    [ApiController]
    public class UserLinkController : ControllerBase
    {
        public UserLinkController(IWebHostEnvironment hostenv, IUserLinkJsonReader ulreader)
        {
            WebHostEnv = hostenv;
            UlReader = ulreader;
        }

        public IWebHostEnvironment WebHostEnv { get; set; }
        public IUserLinkJsonReader UlReader { get; set; }
        public async Task<List<UserLink>> GetAsync(string username)
        {
            return await GetUserLinksAsync(username);

        }
        protected async Task<List<UserLink>> GetUserLinksAsync(string username)
        {
            string jsonString = await GetUserLinksStringAsync(username);

            return UlReader.GetUserLinksFrom(jsonString);

        }

        private async Task<string> GetUserLinksStringAsync(string username)
        {
            string filepath = Path.Combine(WebHostEnv.ContentRootPath, $"UserContent/users/{username}/{username}.json");
            return await System.IO.File.ReadAllTextAsync(filepath);
        }
    }
}
