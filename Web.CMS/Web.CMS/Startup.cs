using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Service;
using System.IO;

namespace Web.CMS
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
            services.AddMvc();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IServiceHandler, ServiceHandler>();
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            var connectionStringConfig = builder.Build();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // Add "appsettings.json" to bootstrap EF config.
                .AddJsonFile("appsettings.json");

            ServiceConfiguration.serviceUrl = connectionStringConfig.GetValue(typeof(string), "APIUrl:api").ToString();

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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {                 
                 routes.MapAreaRoute(
                    name: "default",
                    areaName:"Contact",
                    template:"{controller=Contact}/{action=Create}/{id?}");
            });
        }
    }
}
