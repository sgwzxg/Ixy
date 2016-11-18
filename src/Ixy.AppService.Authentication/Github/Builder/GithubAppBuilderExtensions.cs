using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Ixy.AppService.Authentication.Github.Builder
{
    public static class GithubAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" /> middleware to the specified <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />, which enables Microsoft Account authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
		public static IApplicationBuilder UseGithubAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            return UseMiddlewareExtensions.UseMiddleware<GithubMiddleware>(app, Array.Empty<object>());
        }

        /// <summary>
        /// Adds the <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" /> middleware to the specified <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" />, which enables Microsoft Account authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="T:Microsoft.AspNetCore.Builder.IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="options">A <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" /> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseGithubAuthentication(this IApplicationBuilder app,
            GithubOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
            return UseMiddlewareExtensions.UseMiddleware<GithubMiddleware>(app, new object[]
            {
                Options.Create<GithubOptions>(options)
            });
        }
    }
}
