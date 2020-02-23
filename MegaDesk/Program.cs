using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MegaDesk.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MegaDesk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Add the code for seeding the DB if it is empty

            // Need Microsoft.Extensions.DependencyInjection for this to work
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    TestData.Initialize(services);
                } catch (Exception ex)
                {
                    var logMessage = services.GetRequiredService<ILogger<Program>>();
                    logMessage.LogError(ex, "Oops, something went wrong when we tried to seed the database.  Let the devs know so they can try to figure it out.");
                }

            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
