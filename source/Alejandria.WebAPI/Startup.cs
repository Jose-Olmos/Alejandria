using Alejandria.WebAPI.Implementation.Configure;
using Devon4Net.Application.WebAPI.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alejandria.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration; 

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDevonFw(_configuration);
            services.SetupDevonDependencyInjection(_configuration);
            services.AddControllers();
            services.AddOptions();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment _)
        {
            app.UseHsts();
            app.UseStaticFiles();
            app.ConfigureDevonFw();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
