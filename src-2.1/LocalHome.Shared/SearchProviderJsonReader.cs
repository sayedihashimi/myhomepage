using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LocalHome.Shared {
    public class SearchProviderJsonReader : ISearchProviderJsonReader {
        public async Task<List<SearchProvider>> GetSearchProvidersFromFileAsync(string filepath) {
            Debug.Assert(filepath != null);
            Debug.Assert(File.Exists(filepath));

            return GetSearchProvidersFrom(await File.ReadAllTextAsync(filepath));
            throw new NotImplementedException();
        }

        public List<SearchProvider> GetSearchProvidersFrom(string json) {
            Debug.Assert(json != null);
            List<SearchProvider> result = JsonConvert.DeserializeObject<List<SearchProvider>>(json);
            return result;
        }
    }
}
