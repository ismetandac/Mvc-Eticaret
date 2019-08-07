using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace And.Eticaret.API
{
    public partial class LoginProvider : OAuthAuthorizationServerProvider
    {
        public User Login(string email, string password)
        {
            var db = new AndDB();
            var usr = db.Users.Where(x => x.Email == email && x.Password == password && x.IsActive == true).ToList();
            if (usr.Count > 0)
            {
                // Giriş Başarılı
                return usr.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var usr = Login(context.UserName, context.Password);
            if (usr == null)
            {
                //Hatalı
                context.SetError("invalid_grant", "Hatalı Kullanıcı Bilgisi");
            }
            else
            {
                //Başarılı
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserName", context.UserName));
                identity.AddClaim(new Claim("Password", context.Password));
                identity.AddClaim(new Claim("UserID", usr.ID.ToString()));

                context.Validated(identity);
            }
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}