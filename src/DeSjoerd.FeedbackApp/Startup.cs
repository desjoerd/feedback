using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DeSjoerd.FeedbackApp
{
    public class Startup
    {   
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Feedback}/{action=Index}/{id?}");
            });
        }
    }
}