using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(And.Eticaret.API.Startup))]
namespace And.Eticaret.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new LoginProvider()
            });
        }


    }
}