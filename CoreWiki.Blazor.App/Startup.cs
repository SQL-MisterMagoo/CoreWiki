using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Blazor.App.Services;
using CoreWiki.Configuration.Startup;
using CoreWiki.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CoreWiki.Blazor.App
{
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			// Since Blazor is running on the server, we can use an application service
			// to read the forecast data.
			IConfiguration Configuration = new ConfigurationBuilder().Build();
			services.AddSingleton(Configuration);
			services.ConfigureAutomapper();
			services.Configure<AppSettings>(Configuration);
			services.ConfigureApplicationServices();
			services.AddMediator();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
