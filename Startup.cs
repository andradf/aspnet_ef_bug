using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConcurrencyBug.Data;
using System.Data.SqlClient;

namespace ConcurrencyBug
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Concurrency-597f84ce-3ce1-46ca-a678-119126447a78;Trusted_Connection=True;MultipleActiveResultSets=true";

            ////this works
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connStr));

            //this does not work
            var conn = new SqlConnection(connStr);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conn));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
