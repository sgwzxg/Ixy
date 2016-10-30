using Ixy.Core.Model.Identity;
using Ixy.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ixy.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add data context
            services.AddDbContext<IxyDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IxyUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<IxyDbContext>()
            .AddDefaultTokenProviders();

            RegisterServices.Run(services);

            services.AddMvc();
        }
         
        private OAuthOptions GithubOptions => new OAuthOptions
        {
            AuthenticationScheme = "Github",
            DisplayName = "Github",
            ClientId = Configuration["Github:ClientId"],
            ClientSecret = Configuration["Github:ClientSecret"],
            CallbackPath = new PathString("/signin-github"),
            AuthorizationEndpoint = "https://github.com/login/oauth/authorize",
            TokenEndpoint = "https://github.com/login/oauth/access_token",
            UserInformationEndpoint = "https://api.github.com/user",
            ClaimsIssuer = "OAuth2-Github",
            SaveTokens = true,
            Events = new OAuthEvents
            {
                OnCreatingTicket = async context => { await CreateGitHubAuthTicket(context); }
            }
        };

        private static async Task CreateGitHubAuthTicket(OAuthCreatingTicketContext context)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();
            var user = JObject.Parse(await response.Content.ReadAsStringAsync());

            AddClaim(context, user);
        }

        private static void AddClaim(OAuthCreatingTicketContext context, JObject user)
        {
            var id = user.Value<string>("id");
            if (!string.IsNullOrEmpty(id))
            {
                context.Identity.AddClaim(new System.Security.Claims.Claim(
                    ClaimTypes.NameIdentifier, id,
                    ClaimValueTypes.String, context.Options.ClaimsIssuer
                    ));
            }

            var userName = user.Value<string>("login");
            if (!string.IsNullOrEmpty(userName))
            {
                context.Identity.AddClaim(new Claim(
                    ClaimsIdentity.DefaultNameClaimType, userName,
                    ClaimValueTypes.String, context.Options.ClaimsIssuer
                    ));
            }

            var name = user.Value<string>("name");
            if (!string.IsNullOrEmpty(name))
            {
                context.Identity.AddClaim(new Claim(
                    "urn:github:name", name,
                    ClaimValueTypes.String, context.Options.ClaimsIssuer
                    ));
            }

            var link = user.Value<string>("url");
            if (!string.IsNullOrEmpty(link))
            {
            context.Identity.AddClaim(new Claim(
                "urn:github:url", link,
                ClaimValueTypes.String, context.Options.ClaimsIssuer
                ));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseOAuthAuthentication(GithubOptions);
            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions());
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areaRoute",
                   template: "{area:exists}/{controller}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
