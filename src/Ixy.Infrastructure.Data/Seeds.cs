using Ixy.Core.Model.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Data
{
    //85, 123,205
    public static class Seeds
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IxyDbContext(serviceProvider.GetRequiredService<DbContextOptions<IxyDbContext>>()))
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(new IxyUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "sgwzxg@hotmail.com",
                        EmailConfirmed = true,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true,
                        NormalizedEmail = "sgwzxg@hotmail.com",
                        NormalizedUserName = "sgwzxg@hotmail.com",
                        UserName = "sgwzxg@hotmail.com",
                    });
                }

                if (!context.Roles.Any())
                {

                }
                context.SaveChanges();
            }
        }
    }
}
