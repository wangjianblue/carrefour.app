using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Carrefour.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
                .ConfigureLogging((context, logBuilder) =>
                {
                    logBuilder.AddFilter("System", LogLevel.Warning);
                    logBuilder.AddFilter("Microsoft", LogLevel.Warning);
                    logBuilder.AddLog4Net(); //注锟斤拷log4net
                }) 
                .ConfigureAppConfiguration((hostingContext,config)=>{
                    config.AddCommandLine(args); //鏀寔鍛戒护
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
