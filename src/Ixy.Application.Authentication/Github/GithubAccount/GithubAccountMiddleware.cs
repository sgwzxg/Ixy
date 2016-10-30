﻿using Ixy.Application.Authentication.GithubAccount.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Ixy.Application.Authentication.GithubAccount
{
    /// <summary>
    /// An ASP.NET Core middleware for authenticating users using the Microsoft Account service.
    /// </summary>
    public class GithubAccountMiddleware : OAuthMiddleware<GithubAccountOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware" />.
        /// </summary>
        /// <param name="next">The next middleware in the HTTP pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        public GithubAccountMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<GithubAccountOptions> options) : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException("dataProtectionProvider");
            }
            if (loggerFactory == null)
            {
                throw new ArgumentNullException("loggerFactory");
            }
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }
            if (sharedOptions == null)
            {
                throw new ArgumentNullException("sharedOptions");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
        }

        /// <summary>
        /// Provides the <see cref="T:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1" /> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="T:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1" /> configured with the <see cref="T:Microsoft.AspNetCore.Builder.MicrosoftAccountOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<GithubAccountOptions> CreateHandler()
        {
            return new GithubAccountHandler(Backchannel);
        }
    }
}
