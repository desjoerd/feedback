using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DeSjoerd.FeedbackApp
{
    public class Startup
    {   
        public Startup()
        {

        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();

            services.AddDbContext<Models.FeedbackContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DeSjoerd.FeedbackApp;Trusted_Connection=True;Integrated Security=true"));
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