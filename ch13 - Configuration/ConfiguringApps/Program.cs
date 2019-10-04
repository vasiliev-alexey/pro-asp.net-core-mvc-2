namespace ConfiguringApps
{
    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webBuilder =>
                    {
                        webBuilder.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseIISIntegration()
                            .UseStartup<Startup>();
                    });
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}