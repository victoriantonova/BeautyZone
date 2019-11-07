using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyZone.DAL;
using BeautyZone.DAL.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BeautyZone.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {

                    DatabaseContext context = services.GetRequiredService<DatabaseContext>();
                    RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //SampleData.Initialize(context, roleManager, userManager);

                    //ICategoryService categoryService = services.GetRequiredService<ICategoryService>();
                    //IRegionService regionService = services.GetRequiredService<IRegionService>();
                    //ICacheService cacheService = new CacheService();
                    //cacheService.CacheCategories(categoryService);
                    //cacheService.CacheRegions(regionService);

                    Microsoft.EntityFrameworkCore.DbSet<ApplicationUser> a = context.ApplicationUsers;
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        private static int UserManager<T>()
        {
            throw new NotImplementedException();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
