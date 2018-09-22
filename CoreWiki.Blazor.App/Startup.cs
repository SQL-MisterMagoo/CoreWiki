using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CoreWiki.Blazor.App.Services;

namespace CoreWiki.Blazor.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// Since Blazor is running on the server, we can use an application service
			// to read the forecast data.
			services.AddLocalization();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
