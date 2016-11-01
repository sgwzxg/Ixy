using Ixy.Application.Authentication.Github.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Web
{
    public class RegisterExternalAuthentication
    {
        public static void Run(IApplicationBuilder app, IConfigurationRoot configuration)
        {
            var microsoftAccountOptions = new MicrosoftAccountOptions()
            {
                AuthenticationScheme="Sign in with Microsoft",
                ClientId = configuration["Microsoft:ClientId"],
                ClientSecret = configuration["Microsoft:ClientSecret"]
            };

            microsoftAccountOptions.Description.Items.Add("LoginCss", "btn-social btn-microsoft");
            microsoftAccountOptions.Description.Items.Add("IconCss", "fa fa-windows");
            app.UseMicrosoftAccountAuthentication(microsoftAccountOptions);

            var githubOptions = new GithubOptions()
            {
                AuthenticationScheme = "Sign in with Github",
                ClientId = configuration["Github:ClientId"],
                ClientSecret = configuration["Github:ClientSecret"]
            };
            githubOptions.Description.Items.Add("LoginCss", "btn-social btn-github");
            githubOptions.Description.Items.Add("IconCss", "fa fa-github");
            app.UseGithubAuthentication(githubOptions);

            var facebookOptions = new FacebookOptions()
            {
                AuthenticationScheme = "Sign in with Facebook",
                ClientId = configuration["Facebook:ClientId"],
                ClientSecret = configuration["Facebook:ClientSecret"]
            };
            facebookOptions.Description.Items.Add("LoginCss", "btn-social btn-facebook");
            facebookOptions.Description.Items.Add("IconCss", "fa fa-facebook");
            app.UseFacebookAuthentication(facebookOptions);
        }
    }
}
