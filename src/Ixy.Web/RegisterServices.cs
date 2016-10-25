using Ixy.Application.Services;
using Ixy.Applications.Services;
using Ixy.EntityFrameworkCore.Infrastructure;
using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Ixy.EntityFrameworkCore.Infrastructure.Repositories;
using Ixy.Models.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
