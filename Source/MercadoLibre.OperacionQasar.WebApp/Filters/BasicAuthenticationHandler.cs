using MercadoLibre.OperacionQasar.WebApp.Models;
using MercadoLibre.OperacionQuasar.Core.Domain;
using MercadoLibre.OperacionQuasar.Core.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MercadoLibre.OperacionQasar.WebApp.Filters
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserDomain _userDomain;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserDomain userDomain)
            : base(options, logger, encoder, clock)
        {
            _userDomain = userDomain;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header missing.");
            }

            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
            {
                return AuthenticateResult.Fail("Authorization code not formatted properly.");
            }

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));

            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var authPassword = authSplit.Length > 1 ? authSplit[1] : throw new Exception("Unable to get password");
            var authPasswordEncrypted = Encrypt.GetSHA256(authPassword);

            var userData = await _userDomain.GetUserByEmailAsync(authUsername);

            bool validPassword = userData != null && string.Equals(userData.Password, authPasswordEncrypted, StringComparison.CurrentCultureIgnoreCase);

            if (validPassword)
            {
                var authenticatedUser = new AuthenticatedUserModel()
                {
                    AuthenticationType = Constants.BASIC_AUTHENTICATION_SCHEMA,
                    IsAuthenticated = true,
                    Name = userData.Name,
                };  

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authenticatedUser));

                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
            }

            return AuthenticateResult.Fail("The username or password is not correct.");
        }
    }
}
