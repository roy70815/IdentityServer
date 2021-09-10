using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = Configuration.GetConnectionString("DBConnection");
            //var builder = services.AddIdentityServer()
            //    .AddConfigurationStore(opt =>
            //    {
            //        opt.ConfigureDbContext = context =>
            //        {
            //            context.UseMySql(connection, ServerVersion.AutoDetect(connection), sql=> 
            //            {
            //                sql.MigrationsAssembly("IdentityServer");
            //            });
            //        };
            //    });

            services.AddIdentityServer()
            // 方便測試選擇in-memory
            .AddInMemoryClients(Clients.GetClients())
            .AddInMemoryApiResources(Resources.GetApiResources())
            .AddInMemoryApiScopes(Resources.GetApiScopes())
            .AddTestUsers(TestUsers.GetUsers().ToList())
            // 方便開發階段於啟動時產生暫時密鑰(tempkey.jwk)
            .AddDeveloperSigningCredential();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            // 啟用IdentityServer
            app.UseIdentityServer();
            //for QuickStart-UI 啟用靜態檔案
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
