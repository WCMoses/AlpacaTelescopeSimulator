using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.Utilities;
using ASCOMCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASCOMCore
{
    public class Program
    {

        public static TelescopeSimulator Simulator;
        public static TraceLogger TraceLogger;

        public const int ASCOM_ERROR_NUMBER_OFFSET = unchecked((int)0x80040000); // int value of the ASCOM COM error code range

        public static void Main(string[] args)
        {
            Simulator = new TelescopeSimulator();
            TraceLogger = new TraceLogger("TelescopeSimulator");
            TraceLogger.Enabled = true;
            TraceLogger.LogMessage("Main", "Logger created");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();

            TraceLogger.LogMessage("Main", "Running host");
            host.Run();
            TraceLogger.LogMessage("Main", "Program end"); 


            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureLogging((hostingContext, logging) =>
                        {
                            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                            logging.AddConsole();
                            logging.AddDebug();
                            logging.AddEventSourceLogger();
                            logging.SetMinimumLevel(LogLevel.Information);
                        })
                        .Build();

                    TraceLogger.LogMessage("Main", "Running host");

                });
    }
}
