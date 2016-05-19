using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DeSjoerd.FeedbackApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();
            
            var host = new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseIISIntegration()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
                
            host.Run();
        }
    }
}
