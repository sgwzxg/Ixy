using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Ixy.AppService.Authentication.Github.Builder
{
    /// <summary>
	/// Configuration options for <see cref="T:Microsoft.AspNetCore.Authentication.Github.GithubMiddleware" />.
	/// </summary>
	public class GithubOptions : OAuthOptions
    {
        //https://developer.github.com/v3/oauth/

        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" />.
        /// </summary>
        public GithubOptions()
        {
            AuthenticationScheme = "Github";
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-github");
            AuthorizationEndpoint = GithubDefaults.AuthorizationEndpoint;
            TokenEndpoint = GithubDefaults.TokenEndpoint;
            UserInformationEndpoint = GithubDefaults.UserInformationEndpoint;
            //Grants read-only access to public information (includes public user profile info, public repository info, and gists)
            //Scope.Add("https://graph.microsoft.com/user.read");
        }
    }
}
