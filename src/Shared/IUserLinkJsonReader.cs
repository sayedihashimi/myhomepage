using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalHome.Shared {
    public interface IUserLinkJsonReader {
        List<UserLink> GetUserLinksFrom(string text);
        Task<List<UserLink>> GetUserLinksFromFileAsync(string filepath);
    }
}