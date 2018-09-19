using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CoreWiki.Blazor.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
				WebHost.CreateDefaultBuilder(args)
					.ConfigureAppConfiguration((hostingContext, config) =>
					{
						config.AddCommandLine(args);
						config.AddJsonFile(@"bin\Debug\netcoreapp2.1\appsettings.json");
					}).UseStartup<Startup>()
						.Build();
	}
}
