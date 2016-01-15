using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Data;
using ComlinkStore.Infra.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ComlinkStore.Api.Helpers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var repository = new UserRepository(new ComlinkStoreDataContext());
                var user = repository.GetByUsername(context.UserName);

                if (user == null)
                {
                    context.SetError("Unauthorized", "Usuário ou senha inválidos");
                    return;
                }

                if (!user.Authenticate(context.Password))
                {
                    context.SetError("Unauthorized", "Usuário ou senha inválidos");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("message", "Usuário ou senha inválidos");
            }
        }
    }
}