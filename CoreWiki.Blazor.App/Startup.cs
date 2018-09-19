using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Blazor.App.Services;
using CoreWiki.Configuration.Startup;
using CoreWiki.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreWiki.Blazor.App
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		public Startup()
		{

		}
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			// Since Blazor is running on the server, we can use an application service
			// to read the forecast data.
			ConfigureConfiguration(services);
			services.ConfigureAutomapper();
			services.Configure<AppSettings>(Configuration);
			services.ConfigureDatabase(Configuration);
			services.ConfigureScopedServices();
			services.ConfigureApplicationServices();
			services.AddMediator();
		}

		private void ConfigureConfiguration(IServiceCollection services)
		{
			Configuration = services.BuildServiceProvider().GetService<IConfiguration>();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
