namespace ConfiguringApps
{
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webBuilder =>
                    {
                        webBuilder.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseIISIntegration()
                            .UseStartup<Startup>();

                        webBuilder.ConfigureAppConfiguration(
                            (hc, c) =>
                                {
                                    c.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                                    c.AddEnvironmentVariables();
                                    if (args != null && args.Any())
                                    {
                                        c.AddCommandLine(args);
                                    }
                                });
                    }).ConfigureLogging(
                (hc, logging) =>
                    {
                        logging.AddConfiguration(hc.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                    });
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}