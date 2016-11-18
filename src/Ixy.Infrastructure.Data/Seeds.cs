using Ixy.Core;
using Ixy.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IxyDbContext(serviceProvider.GetRequiredService<DbContextOptions<IxyDbContext>>()))
            {

                if (!context.Users.Any())
                {
                    var passwordHash = new PasswordHasher<IxyUser>();
                    var upperInvariantLookupNormalizer = new UpperInvariantLookupNormalizer();

                    var user = new IxyUser()
                    {
                        Email = "sgwzxg@hotmail.com",
                        EmailConfirmed = true,
                        UserName = "sgwzxg@hotmail.com",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true

                    };

                    user.NormalizedEmail = upperInvariantLookupNormalizer.Normalize(user.Email);
                    user.NormalizedUserName = upperInvariantLookupNormalizer.Normalize(user.UserName);
                    user.PasswordHash = passwordHash.HashPassword(user, "1qaz@WSX");

                    context.Users.Add(user);
                }

                if (!context.MenuItems.Any())
                {
                    context.MenuItems.AddRange(GenerateDefaultMenuItems());
                }
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<MenuItem> GenerateDefaultMenuItems()
        {
            List<MenuItem> menus = new List<MenuItem>();
            menus.Add(
                new MenuItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Dashboard",
                    ParentId = Guid.Empty.ToString(),
                    Type = 0,
                    Serial = 0,
                    Description = "",
                    Url = ""
                }
                );

            string sysId = Guid.NewGuid().ToString();
            menus.Add(
                new MenuItem()
                {
                    Id = sysId,
                    Name = "System Management",
                    ParentId = Guid.Empty.ToString(),
                    Type = 0,
                    Serial = 0,
                    Description = "",
                    Url = ""
                }
                );
            menus.Add(
                new MenuItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Users",
                    ParentId = sysId,
                    Type = 0,
                    Serial = 0,
                    Description = "",
                    Url = ""
                }
                );
            menus.Add(
               new MenuItem()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Roles",
                   ParentId = sysId,
                   Type = 0,
                   Serial = 0,
                   Description = "",
                   Url = ""
               }
               );
            menus.Add(
               new MenuItem()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Menu",
                   ParentId = sysId,
                   Type = 0,
                   Serial = 0,
                   Description = "",
                   Url = ""
               }
               );

            string blogId = Guid.NewGuid().ToString();
            menus.Add(
                new MenuItem()
                {
                    Id = blogId,
                    Name = "Blog Management",
                    ParentId = Guid.Empty.ToString(),
                    Type = 0,
                    Serial = 0,
                    Description = "",
                    Url = ""
                }
                );
            menus.Add(
              new MenuItem()
              {
                  Id = Guid.NewGuid().ToString(),
                  Name = "Posts",
                  ParentId = blogId,
                  Type = 0,
                  Serial = 0,
                  Description = "",
                  Url = ""
              }
              );
            menus.Add(
             new MenuItem()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "Tags",
                 ParentId = blogId,
                 Type = 0,
                 Serial = 0,
                 Description = "",
                 Url = ""
             }
             );
            menus.Add(
            new MenuItem()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Categories",
                ParentId = blogId,
                Type = 0,
                Serial = 0,
                Description = "",
                Url = ""
            }
            );
            return menus;
        }
    }
}
