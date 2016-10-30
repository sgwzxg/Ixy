using Ixy.Application.Authentication.GithubAccount.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ixy.Application.Authentication.GithubAccount
{
    internal class GithubAccountHandler : OAuthHandler<GithubAccountOptions>
    {

        public GithubAccountHandler(HttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            HttpResponseMessage response = await Backchannel.SendAsync(request, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            JObject jObject = JObject.Parse(await response.Content.ReadAsStringAsync());
            AuthenticationTicket authenticationTicket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
            OAuthCreatingTicketContext oAuthCreatingTicketContext = new OAuthCreatingTicketContext(authenticationTicket, Context, Options, Backchannel, tokens, jObject);
            string id = GithubAccountHelper.GetId(jObject);
            if (!string.IsNullOrEmpty(id))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", id, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:githubaccount:id", id, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
            }
            string displayName = GithubAccountHelper.GetDisplayName(jObject);
            if (!string.IsNullOrEmpty(displayName))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", displayName, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:githubaccount:name", displayName, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
            }
            string givenName = GithubAccountHelper.GetUrl(jObject);
            if (!string.IsNullOrEmpty(givenName))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", givenName, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:microsoftaccount:url", givenName, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
            }
            string surname = GithubAccountHelper.GetName(jObject);
            if (!string.IsNullOrEmpty(surname))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname", surname, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:microsoftaccount:surname", surname, "http://www.w3.org/2001/XMLSchema#string", Options.ClaimsIssuer));
            }
           
            await Options.Events.CreatingTicket(oAuthCreatingTicketContext);
            return oAuthCreatingTicketContext.Ticket;
        }
    }
}
