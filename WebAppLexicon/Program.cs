using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Database;
using WebAppLexicon.Models.Identity;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();

        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MemberDbContext>();
                    // Inside CreateDbIfNotExists method.
                    RoleManager<IdentityRole> roleManager =
                    services.GetRequiredService<RoleManager<IdentityRole>>();
                    UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();
                    _ = DbInitializer.InitializeAsyn(context, roleManager, userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating the DB.");
                }
            }
        }
    }
}
