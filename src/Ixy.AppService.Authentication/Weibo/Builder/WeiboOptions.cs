using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Ixy.AppService.Authentication.Weibo.Builder
{
    /// <summary>
	/// Configuration options for <see cref="T:Microsoft.AspNetCore.Authentication.Github.GithubMiddleware" />.
	/// </summary>
	public class WeiboOptions : OAuthOptions
    {
        //https://developer.github.com/v3/oauth/

        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" />.
        /// </summary>
        public WeiboOptions()
        {
            AuthenticationScheme = "Weibo";
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-weibo");
            AuthorizationEndpoint = WeiboDefaults.AuthorizationEndpoint;
            TokenEndpoint = WeiboDefaults.TokenEndpoint;
            UserInformationEndpoint = WeiboDefaults.UserInformationEndpoint;
            //Grants read-only access to public information (includes public user profile info, public repository info, and gists)
            //Scope.Add("https://graph.microsoft.com/user.read");
        }
    }
}
