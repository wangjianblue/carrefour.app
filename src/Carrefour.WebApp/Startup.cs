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
using Carrefour.Core.Redis;
using Carrefour.Web.Framework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using Carrefour.Core.Mongodb;
using MongoDB.Driver;

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
            //services.AddHostedService<WebHostGroundService>();
            services.AddTransient<IProduct, Product>();
            services.AddControllersWithViews();
            services.AddHttpClient("ProductHttpClient", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("HttpClient:ProductHttpClient:url").Value);
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
            services.AddSingleton<ICacheService>(new RedisManager(p =>
            {
                p.Configuration = Configuration.GetSection("RedisOptions:Configuration").Value;
                p.InstanceName = Configuration.GetSection("RedisOptions:InstanceName").Value;
            }));
  
            var mongoUrl = new MongoUrlBuilder(Configuration.GetSection("MongoOptions:mongodb").Value);  
            MongoCredential credentials = MongoCredential.CreateCredential(mongoUrl.DatabaseName, mongoUrl.Username, mongoUrl.Password);//添加用户名、密码
       
            services.AddSingleton<IMongoRepository>(new MongoRepository((action) =>
            {
                action.Credential = credentials;
                action.ConnectTimeout=new TimeSpan(30000);//设置连接超时时长
                action.MaxConnectionPoolSize = 20000;//设置连接池最大连接数
                action.Server = mongoUrl.Server;
                action.ConnectionMode = ConnectionMode.Standalone;
                action.ReadPreference = new ReadPreference(ReadPreferenceMode.Primary);
                action.ServerSelectionTimeout = TimeSpan.FromSeconds(10);
            }));
          


            //services.AddApplicationInsightsTelemetry();
            //Cookie(1)閿熸枻鎷烽敓鏂ゆ嫹 Cookie 閿熸枻鎷烽敓鏂ゆ嫹
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) //鍓嶅彴閿熺煫浼欐嫹cookie閿熸枻鎷烽敓鏂ゆ嫹
                .AddCookie(MyAuthorization.UserAuthenticationScheme, options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.LogoutPath = "/Login/LogOff";
                    options.AccessDeniedPath = new PathString("/Error/Forbidden");//閿熸澃鎾呮嫹閿熸枻鎷烽敓鏂ゆ嫹椤甸敓鏂ゆ嫹
                    options.Cookie.Path = "/";
                }); 
            services.AddControllers((filter) => { filter.Filters.Add(typeof(MyAuthorization)); });


            // 娉ㄩ敓鏂ゆ嫹Swagger閿熸枻鎷烽敓鏂ゆ嫹
            services.AddSwaggerGen(c =>
            {
                // 閿熸枻鎷烽敓鏂ゆ嫹閿熶茎纰夋嫹閿熸枻鎷锋伅
                // 閿熸枻鎷烽敓鏂ゆ嫹閿熶茎纰夋嫹閿熸枻鎷锋伅
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CoreWebApi",
                    Version = "v1",
                    Description = "ASP.NET CORE WebApi",
                    Contact = new OpenApiContact
                    {
                        Name = "gary",
                        Email = "gary@gmail.com"
                    }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
            // 閿熸枻鎷烽敓鏂ゆ嫹Swagger閿熷彨纭锋嫹閿燂拷
            app.UseSwagger();

            // 閿熸枻鎷烽敓鏂ゆ嫹SwaggerUI
            app.UseSwaggerUI(c =>
            {
                // 閿熸枻鎷烽敓鏂ゆ嫹閿熶茎纰夋嫹閿熸枻鎷锋伅
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi");
                c.RoutePrefix = string.Empty;

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
