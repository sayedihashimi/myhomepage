using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace LocalHome.Shared {
    public class UserLinkJsonReader : IUserLinkJsonReader {
        public List<UserLink> GetUserLinksFromFile(string filepath) {
            Debug.Assert(filepath != null);
            return GetUserLinksFrom(File.ReadAllText(filepath));
        }

        public List<UserLink> GetUserLinksFrom(string text) {
            Debug.Assert(text != null);
            List <UserLink> result = JsonConvert.DeserializeObject<List<UserLink>>(text);
            return result;
        }
    }
}
