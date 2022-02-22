using BibliotecaMVC.Models.Contracts.Contexts;
using BibliotecaMVC.Models.Contracts.Repositories;
using BibliotecaMVC.Models.Contracts.Services;
using BibliotecaMVC.Models.Repositories;
using BibliotecaMVC.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC
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
            services.AddControllersWithViews();

            
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddSingleton<IContextData, ContextDataFake>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivroService, LivroService>();
            ConfiguraDataSource(services);
        }

        public void ConfiguraDataSource(IServiceCollection services)
        {
            string datasource = Configuration["DataSource"];

            switch (datasource)
            {
                case "Local":
                    services.AddSingleton<IContextData, ContextDataFake>();
                    break;

                case "SqlServer":
                    services.AddSingleton<IContextData, ContextDataSqlServer>();
                    services.AddSingleton<IConnectionManager, ConnectionManager>();
                    break;

            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
