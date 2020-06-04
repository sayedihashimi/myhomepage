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
    [Route("api/[controller]/{username?}")]
    [ApiController]
    public class SeachProviderController : ControllerBase
    {
        private IWebHostEnvironment WebHostEnv { get; set; }
        private ISearchProviderJsonReader SpReader { get; set; }
        private string foo;
        public SeachProviderController(IWebHostEnvironment webhostenv, ISearchProviderJsonReader spReader)
        {
            WebHostEnv = webhostenv;
            SpReader = spReader;
        }

        public async Task<List<SearchProvider>> GetAsync(string username)
        {
            // TODO: Get this from somewhere
            if (string.IsNullOrEmpty(username)) { username = "sayedha"; }
            string filepath = Path.Combine(WebHostEnv.ContentRootPath, $"UserContent/users/{username}/search.json");
            return await SpReader.GetSearchProvidersFromFileAsync(filepath);
        }
    }
}
