using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalHome.Shared {
    public interface ISearchProviderJsonReader {
        List<SearchProvider> GetSearchProvidersFrom(string json);
        Task<List<SearchProvider>> GetSearchProvidersFromFileAsync(string filepath);
    }
}