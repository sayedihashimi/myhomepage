using System.Collections.Generic;

namespace LocalHome.Shared {
    public interface IUserLinkJsonReader {
        List<UserLink> GetUserLinksFrom(string text);
        List<UserLink> GetUserLinksFromFile(string filepath);
    }
}