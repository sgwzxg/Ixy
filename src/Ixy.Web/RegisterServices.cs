using Ixy.Application.Interfaces;
using Ixy.Application.Services;
using Ixy.Core.Interfaces;
using Ixy.Infrastructure;
using Ixy.Infrastructure.Interfaces;
using Ixy.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ixy.Web
{
    public class RegisterServices
    {
        public static void Run(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
        }
    }
}
