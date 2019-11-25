using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHome.Shared;

namespace LocalHome.Services {
    public interface IAddLinkToJsonFileService {
        Task AddLinkAsync(string jsonFilePath, UserLink userLink);
        Task AddLinksAsync(string jsonFilePath, IEnumerable<UserLink> userLinks);
    }
}