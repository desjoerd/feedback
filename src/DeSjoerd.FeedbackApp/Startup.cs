using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeSjoerd.FeedbackApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            
            services.AddDbContext<Models.FeedbackContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Feedback}/{action=Index}/{id?}");
            });
        }
    }
}