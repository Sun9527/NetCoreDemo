using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCoreSchool.Ef;

namespace NetCoreSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                     
                    var context = services.GetRequiredService<NetCoreSchoolDbContext>();
                    DbInit.Initialize(context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetService<ILogger<Program>>();

                    logger.LogError("报错了+"+ex.Message);
                }
            }

            host.Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
