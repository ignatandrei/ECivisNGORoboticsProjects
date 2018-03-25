using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECivisObj.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECivisWebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=NGORobotics;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<NGORoboticsContext>(options => options.UseSqlServer(connection));
            var dir1 = Env.ContentRootPath;
            var pathFolderDB = new DirectoryInfo(dir1).Parent.Parent.Parent.GetDirectories("sql").First().FullName;
            var pathDB = Path.Combine(pathFolderDB, "ngoRob.db");
            if (!File.Exists(pathDB))
                throw new ArgumentException("pathdb does not exists");

            var dir2 = Env.WebRootPath;
            var connection = $@"Data Source={pathDB}";
            services.AddDbContext<NGORoboticsContext>(opt => opt.UseSqlite(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(" / Home/Error");
            }

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
