using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;

[assembly: OwinStartup(typeof(AuthorizationServer.Startup))]

namespace AuthorizationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var options = new IdentityServerOptions();
            SetOptions(options);
            app.UseIdentityServer(options);
        }

        private void SetOptions(IdentityServerOptions options)
        {
            //var certificate = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["SigningCertificate"]);
            //string password = System.Configuration.ConfigurationManager.AppSettings["SigningCertificatePwd"];
            options.SigningCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"C:\temp\combined.pfx", "password");
            options.RequireSsl = false; //do not use https

            var manager = new InMemoryManager();
            options.Factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(manager.Users())
                .UseInMemoryClients(manager.Clients())
                .UseInMemoryScopes(manager.Scopes());
        }
    }
}
