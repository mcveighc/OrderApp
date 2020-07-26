using BGLOrderApp.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGLOrderApp.Auth.Authentication
{

    public class BearerAuthenticationOptions : AuthenticationSchemeOptions { }
    public class AuthenticationHandler : AuthenticationHandler<BearerAuthenticationOptions>
    {
        private const string NamedUser = "BGLUser";

        public AuthenticationHandler(
            IOptionsMonitor<BearerAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) 
                return AuthenticateResult.Fail("Unauthorized");

            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer"))
            {
                return AuthenticateResult.NoResult();
            }

            // Get auth token object from auth header
            InsecureAuthToken authToken = await GetToken(authorizationHeader);

            // Check we have the expected user
            if (authToken.User != NamedUser) 
                return AuthenticateResult.Fail("Invalid user");

            // If we have the expected user, get their claims
            var claims = new List<Claim>()
            {
                new Claim("isAdmin", authToken.isAdmin.ToString(), ClaimValueTypes.Boolean)
            };

            // Create auth ticket from claims
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new GenericPrincipal(identity, null);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);

        }

        private static async Task<InsecureAuthToken> GetToken(string authorizationHeader)
        {
            var base64BearerToken = authorizationHeader.Substring(7);
            var tokenBytes = Convert.FromBase64String(base64BearerToken);

            string tokenBody = "";
            using (var stream = new MemoryStream(tokenBytes))
            using (var s = new StreamReader(stream))
            {
                tokenBody = await s.ReadToEndAsync();
            }

            var authToken = JsonSerializer.Deserialize<InsecureAuthToken>(tokenBody, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });

            return authToken;
        }
    }
}
