using System;
using LocalHome.Shared;
using Microsoft.AspNetCore.Components.Web;

namespace LocalHome {
    public class UserLinkEventArgs : EventArgs {

        public UserLinkEventArgs() { }
        public UserLinkEventArgs(UserLink userLink) : this() {
            UserLink = userLink;
        }

        public UserLink UserLink { get; set; }

    }
}
