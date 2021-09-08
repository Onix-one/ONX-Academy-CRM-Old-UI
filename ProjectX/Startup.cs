using System;
using System.Threading.Tasks;
using AcademyCRM.MVC.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ProjectX.DAL.EF.Contexts;
using ProjectX.MVC.ServiceExtensions;

namespace ProjectX.MVC
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddDbContext<Context>(options =>
                options.UseSqlServer
                    (Configuration["SqlServer:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            services.AddMapper();
            services.AddRepositories();
            services.AddEntitiesServices();
            services.AddControllersWithViews();

            services.AddControllersWithViews()
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

            services.Configure<SecurityOptions>(
                Configuration.GetSection(SecurityOptions.SectionTitle));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider,
            IOptions<SecurityOptions> securityOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
                endpoints.MapRazorPages();
            });
            CreateRoles(serviceProvider, securityOptions).Wait();
            //app.UseStatusCodePages("text/plain", "Error. Code: {0}");
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "manager",
                NormalizedName = "MANAGER"
            });

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


            var manager = await userManager.FindByEmailAsync(securityOptions.Value.ManagerUserEmail);

            if (manager != null)
            {
                await userManager.AddToRoleAsync(manager, "MANAGER");
            }
        }
    }
}

