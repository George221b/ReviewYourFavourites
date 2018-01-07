namespace ReviewYourFavourites.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Data.Models;
    using System;
    using System.Threading.Tasks;
    using ReviewYourFavourites.Data.Models.Enums;
    using System.IO;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ReviewYourFavouritesDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdministratorRole;
                        var proUserName = WebConstants.ProUserRole;

                        var roles = new[]
                        {
                            adminName,
                            proUserName
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@admin.com";
                        var proUserEmail = "pro@pro.com";

                        var adminUser = await userManager.FindByEmailAsync(adminEmail);
                        var proUser = await userManager.FindByEmailAsync(proUserEmail);

                        var avatar = File.ReadAllBytes(WebConstants.DefaultAvatarPath);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName,
                                Name = adminName,
                                Birthday = DateTime.UtcNow,
                                Gender = Gender.Female,                      
                                Avatar = avatar
                            };

                            await userManager.CreateAsync(adminUser, "Admin2017");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }

                        if (proUser == null)
                        {
                            proUser = new User
                            {
                                Email = proUserEmail,
                                UserName = proUserName,
                                Name = proUserName,
                                Birthday = DateTime.UtcNow,
                                Gender = Gender.Female,
                                Avatar = avatar
                            };

                            await userManager.CreateAsync(proUser, "ProUser2017");

                            await userManager.AddToRoleAsync(proUser, proUserName);
                        }

                    })
                    .Wait();
            }

            return app;
        }
    }
}
