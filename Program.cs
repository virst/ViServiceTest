using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Globalization;

namespace ViServiceTest
{
    internal class Program
    {
        static Program()
        {
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

            var lc = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console(formatProvider: new CultureInfo("ru-RU"))
               .WriteTo.File("logs/infolog.txt", rollingInterval: RollingInterval.Day);
            Log.Logger = lc.CreateBootstrapLogger();
        }

        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .UseSerilog()
                .UseWindowsService(options =>
                {
                    options.ServiceName = ".NET Vi Service";
                })
                .ConfigureServices((context, collection) =>
                {
                    collection.AddHostedService<FileService>();
                });
    }
}