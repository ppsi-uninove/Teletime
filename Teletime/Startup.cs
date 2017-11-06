using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teletime.Models;
using Microsoft.EntityFrameworkCore;

namespace Teletime
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connection = Configuration.GetConnectionString("TeletimeContext");
            services.AddDbContext<TeletimeContext>(options => options.UseSqlServer(connection));

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

			//try
			//{
			//	using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
			//		.CreateScope())
			//	{

			//		serviceScope.ServiceProvider.GetService<TeletimeContext>()
			//			.Database.Migrate();
			//	}
			//}
			//catch (Exception e)
			//{
			//	var msg = e.Message;
			//	var stacktrace = e.StackTrace;
			//}
        }
    }
}
