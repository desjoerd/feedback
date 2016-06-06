using System;
using System.IO;
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
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(configuration)
                .UseIISIntegration()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            var env = host.Services.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
            if(env.IsDevelopment())
            {
                System.Net.WebRequest.CreateHttp("http://localhost:3000/__browser_sync__?method=reload").GetResponseAsync();
            }

            host.Run();
        }
    }
}
