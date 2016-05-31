using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AuthorizationServer
{
    public class InMemoryManager
    {
        public List<InMemoryUser> Users()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Subject = "test@mail.com",
                    Username = "test@mail.com",
                    Password = "test",
                    Claims = new [] {
                        new Claim(Constants.ClaimTypes.Name, "test name")
                    }
                }
            };
        }

        public IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "social network",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "SocialNetwork",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true
                }
            };
        }

        public IEnumerable<Scope> Scopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope {
                    Name = "read",
                    DisplayName = "read user name"
                }
            };
        }

    }
}