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
            //var nodeServices = Microsoft.AspNetCore.NodeServices.Configuration.CreateNodeServices(new Microsoft.AspNetCore.NodeServices.NodeServicesOptions
            //{
            //    HostingModel = Microsoft.AspNetCore.NodeServices.NodeHostingModel.InputOutputStream,
            //    ProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "tasks")
            //});

            //var result = nodeServices.InvokeExport<object>("./test.js", "test").Result;
            //Console.WriteLine(result);

            //Console.WriteLine("#Reload");
            System.Net.HttpWebRequest.CreateHttp("http://localhost:3000/__browser_sync__?method=reload").GetResponseAsync();

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

            host.Run();
        }
    }
}
