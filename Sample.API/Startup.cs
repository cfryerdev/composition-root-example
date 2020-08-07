using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sample.Composition;

namespace Sample.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Grab the configuration as an object
			services.Configure<ContainerOptions>(Configuration);
			var containerOptions = Configuration.Get<ContainerOptions>();

			// Install the container, using our configuration
			var installer = new ContainerInstaller(containerOptions);
			var builder = installer.Install();

			// Pull the .net core dependencies into the container, like controllers
			builder.Populate(services);

			// Overwrite the unitity service provider with autofac
			return new AutofacServiceProvider(builder.Build());
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
	}
}
