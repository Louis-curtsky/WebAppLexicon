using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Identity;
using WebAppLexicon.Models.Members.Data;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.Services;

namespace WebAppLexicon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //           services.AddControllersWithViews();
            // -------------Connection to Database
            services.AddDbContext<MemberDbContext>
             (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //------------------------- Identity -------------------------------------------------------
            /*            services.AddIdentity<AppUser, IdentityRole>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<MemberDbContext>()
                            .AddDefaultTokenProviders();*/

            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<MemberDbContext>()
             .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            // -------------------- IOC ------------------------
            services.AddScoped<IPeopleRepo, PeopleRepo>();//Container setting for my IoC
            services.AddScoped<IPeopleService, PeopleService>();//Container setting for my IoC

            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICountryServices, CountryServices>();

            services.AddScoped<IStateRepo, StateRepo>();
            services.AddScoped<IStateServices, StateServices>();

            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<ICityServices, CityServices>();

            services.AddMvc().AddRazorRuntimeCompilation();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
/*            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }*/
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
