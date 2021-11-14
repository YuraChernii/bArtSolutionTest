using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace bArtSolutionTest.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    var isDevelopment = environment == Environments.Development;
                    //if (isDevelopment)
                    //{
                    logging.AddConsole();
                    logging.AddFilter(string.Empty, LogLevel.Information);
                    //}
                    //else
                    //{
                    //    //logging.AddApplicationInsights(hostingContext.Configuration["iKeyForProduction"]);
                    //    //logging.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>(
                    //    //    string.Empty, LogLevel.Warning);
                    //}
                });
    }
}
