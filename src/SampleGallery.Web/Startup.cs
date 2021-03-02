using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleGallery.Web.Interfaces;
using SampleGallery.Web.Readers;
using SampleGallery.Web.Services;

namespace SampleGallery.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpClient();

            services.AddTransient<IJsonPlaceholderService, JsonPlaceholderService>();
            services.AddTransient<IJsonPlaceholderReader, JsonPlaceholderReader>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action}/{id}");

                endpoints.MapControllerRoute(
                    name: "index",
                    pattern: "{controller=Home}/{action=Index}/{albumTitle?}/{name?}");
            });
        }
    }
}
