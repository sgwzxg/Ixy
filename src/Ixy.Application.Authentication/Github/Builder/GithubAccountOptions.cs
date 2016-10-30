using Ixy.Application.Authentication.Github;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Application.Authentication.GithubAccount.Builder
{
    /// <summary>
	/// Configuration options for <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" />.
	/// </summary>
	public class GithubAccountOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" />.
        /// </summary>
        public GithubAccountOptions()
        {
            AuthenticationScheme = "Github";
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-github");
            AuthorizationEndpoint = GithubAccountDefaults.AuthorizationEndpoint;
            TokenEndpoint = GithubAccountDefaults.TokenEndpoint;
            UserInformationEndpoint = GithubAccountDefaults.UserInformationEndpoint;
            Scope.Add("https://graph.microsoft.com/user.read");
        }
    }
}
