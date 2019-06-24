using Data.EFCore;
using Data.EFCore.Tests;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
				DbInitializer.Initialize(context);
			}
			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
