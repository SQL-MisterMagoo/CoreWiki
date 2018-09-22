using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Blazor.App.Services;
using CoreWiki.Configuration.Startup;
using CoreWiki.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;
using System.Globalization;

namespace CoreWiki.Blazor.App
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		public Startup()
		{
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Blazor seems to not like injecting into Startup, so I'm using a method to retrieve configuration from the container
			ConfigureConfiguration(services);

			services.ConfigureAutomapper();
			services.Configure<AppSettings>(Configuration);
			services.AddAuthentication();
			services.ConfigureDatabase(Configuration);
			services.ConfigureScopedServices();
			services.ConfigureApplicationServices();
			services.AddMediator();
			services.AddLocalization((options) => { options.ResourcesPath = "Globalization"; });
			//services.AddMvcCore().AddViewLocalization();
			//services.Configure<RequestLocalizationOptions>(options =>
			//{
			//	var supportedCultures = new[]
			//	{
			//							new CultureInfo("en-US"),
			//							new CultureInfo("fr"),
			//							new CultureInfo("ar-YE")
			//					};

			//	// State what the default culture for your application is. This will be used if no specific culture
			//	// can be determined for a given request.
			//	options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
			//});
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
