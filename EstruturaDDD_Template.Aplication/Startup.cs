using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrocoBrq.Data.Context;
using TrocoBrq.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrocoBrq.Data.Migrations;
using AutoMapper;
using TrocoBrq.Aplication.AutoMapper;

namespace TrocoBrq.Aplication
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
            //TODO configurar conection
            var connection = @"Server=(LocalDb)\MSSQLLocalDB;Database=TrocoBrq;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(connection));

            ConfigureMap.Configure();
            // Inject Dependencies.
            DIContainer.RegisterDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CoreContext context)
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
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Troco}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
