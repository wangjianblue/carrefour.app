using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrefour.Core.Domain.RabbitMq;
using Carrefour.Data;
using Carrefour.Services.RabbitMq;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Carrefour.Data.Dapper;
namespace Carrefour.WebApp
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
            #region RabbitMQ
            var rabbitOptions = Configuration.GetSection("RabbitOptions").Get<RabbitOptions>();
            services.AddSingleton<IRabbitMqConnectionFactory>(new RabbitMqConnectionFactory(action =>
            {
                action.HostName = rabbitOptions.HostName;
                action.Port = rabbitOptions.Port;
                action.UserName = rabbitOptions.UserName;
                action.Password = rabbitOptions.Password;
                action.VirtualHost = rabbitOptions.VirtualHost;
            }));

            services.AddSingleton<IRabbitMQHelper>(new RabbitMQHelper(action =>
            {
                action.HostName = rabbitOptions.HostName;
                action.Port = rabbitOptions.Port;
                action.UserName = rabbitOptions.UserName;
                action.Password = rabbitOptions.Password;
                action.VirtualHost = rabbitOptions.VirtualHost;
            }));
            #endregion 
            var connection = Configuration.GetSection("Connections:DefaultConnect").Value;
            services.AddSingleton<IDapperHelper>(new DapperHelper(connection));
            services.AddTransient<IBrowseRecordsReceives, BrowseRecordsReceives>();
            services.AddTransient<IBrowseRecordsReceivesService, BrowseRecordsReceivesService>();
            services.AddHostedService<WebHostGroundService>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
