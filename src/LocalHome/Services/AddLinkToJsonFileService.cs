using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHome.Shared;
using Microsoft.AspNetCore.Hosting;

namespace LocalHome.Services {
    public class AddLinkToJsonFileService : IAddLinkToJsonFileService {

        private IUserLinkJsonReader _userLinkJsonReader;
        private IUserLinkJsonWriter _userLinkJsonWriter;

        public AddLinkToJsonFileService(IUserLinkJsonReader userLinkJsonReader, IUserLinkJsonWriter userLinkJsonWriter) {
            _userLinkJsonReader = userLinkJsonReader;
            _userLinkJsonWriter = userLinkJsonWriter;
        }

        public async Task AddLinkAsync(string jsonFilePath, UserLink userLink) {
            // read existing links into a list, add link, save list back to the file

            var existingLinks = await _userLinkJsonReader.GetUserLinksFromFileAsync(jsonFilePath);
            existingLinks.Add(userLink);
            await _userLinkJsonWriter.WriteUserLinksToFileAsync(jsonFilePath, existingLinks);
        }

        public async Task AddLinksAsync(string jsonFilePath, IEnumerable<UserLink> userLinks) {
            Debug.Assert(!string.IsNullOrEmpty(jsonFilePath));
            Debug.Assert(userLinks != null);

            var existingLinks = await _userLinkJsonReader.GetUserLinksFromFileAsync(jsonFilePath);
            foreach(var ul in userLinks) {
                existingLinks.Add(ul);
            }
            await _userLinkJsonWriter.WriteUserLinksToFileAsync(jsonFilePath, existingLinks);
        }
    }
}
