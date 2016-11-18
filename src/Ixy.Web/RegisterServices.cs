using Ixy.AppService;
using Ixy.AppService.Interface;
using Ixy.Core.Interface;
using Ixy.Infrastructure;
using Ixy.Infrastructure.Data;
using Ixy.Infrastructure.Interface;
using Ixy.Infrastructure.Repository;
using Ixy.Infrastructure.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixy.Web
{
    public class RegisterServices
    {
        public static void Run(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IDbContext,IxyDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.Configure<AuthMessageSenderOptions>(configuration);
        }
    }
}
