using Ixy.Application.Authentication.Github;
using Ixy.Application.Authentication.GithubAccount;
using Ixy.Application.Authentication.GithubAccount.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Application.Authentication.Builder
{
    public static class GithubAccountAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" /> middleware to the specified <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />, which enables Microsoft Account authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
		public static IApplicationBuilder UseGithubAccountAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            return UseMiddlewareExtensions.UseMiddleware<GithubAccountMiddleware>(app, Array.Empty<object>());
        }

        /// <summary>
        /// Adds the <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" /> middleware to the specified <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />, which enables Microsoft Account authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="options">A <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" /> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseMicrosoftAccountAuthentication(this IApplicationBuilder app,GithubAccountOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
            return UseMiddlewareExtensions.UseMiddleware<GithubAccountMiddleware>(app, new object[]
            {
                Options.Create<GithubAccountOptions>(options)
            });
        }
    }
}
