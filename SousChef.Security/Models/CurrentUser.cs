using Microsoft.Identity.Client;
using SousChef.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Security.Models
{
    public class CurrentUser : ICurrentUser
    {
        public string AccessToken
        {
            get;
        }

        public string DisplayableId
        {
            get;
        }

        public string Name
        {
            get;
        }

        public string Identifier
        {
            get;
        }

        public CurrentUser(AuthenticationResult authResult)
        {
            if(authResult == null)
            {
                throw new ArgumentNullException(nameof(authResult));
            }

            if(authResult.User == null)
            {
                throw new ArgumentException("authResult.User cannot be null", nameof(authResult));
            }

            this.AccessToken = authResult.AccessToken;
            this.DisplayableId = authResult.User.DisplayableId;
            this.Name = authResult.User.Name;
            this.Identifier = authResult.User.Identifier;
        }
    }
}
