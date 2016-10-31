using Ixy.Application.Authentication.Weibo.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ixy.Application.Authentication.Weibo
{
    internal class WeiboAccountHandler : OAuthHandler<WeiboOptions>
    {

        public WeiboAccountHandler(HttpClient httpClient)
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
            OAuthCreatingTicketContext oAuthCreatingTicketContext =
                new OAuthCreatingTicketContext(authenticationTicket, Context, Options, Backchannel, tokens, jObject);
            string id = WeiboHelper.GetId(jObject);
            if (!string.IsNullOrEmpty(id))
            {
                identity.AddClaim(new Claim(
                    ClaimTypes.NameIdentifier, id,
                    ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            string login = WeiboHelper.GetLogin(jObject);
            if (!string.IsNullOrEmpty(login))
            {
                identity.AddClaim(new Claim(
                    ClaimsIdentity.DefaultNameClaimType, login, 
                    ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            string name = WeiboHelper.GetName(jObject);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim("urn:github:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            string url = WeiboHelper.GetUrl(jObject);
            if (!string.IsNullOrEmpty(url))
            {
                identity.AddClaim(new Claim("urn:github:url", url, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(oAuthCreatingTicketContext);
            return oAuthCreatingTicketContext.Ticket;
        }
    }
}
