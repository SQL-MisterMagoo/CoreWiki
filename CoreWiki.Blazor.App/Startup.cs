using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Blazor.App.Services;
using CoreWiki.Configuration.Startup;
using Microsoft.Extensions.Configuration;

namespace CoreWiki.Blazor.App
{
	public class Startup
	{
		public IConfiguration Configuration { get; private set; }

		public void ConfigureServices(IServiceCollection services)
		{
			Configuration = services.BuildServiceProvider().GetService<IConfiguration>();
			// Since Blazor is running on the server, we can use an application service
			// to read the forecast data.
			
			services.AddLocalization();
			services.ConfigureAutomapper();
			services.ConfigureDatabase(Configuration);
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			
			app.AddComponent<App>("app");
		}
	}
}
