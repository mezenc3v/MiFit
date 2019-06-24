using Data;
using Data.Services;
using MiBandMaster.Loader.SqlLite;
using MiBandMaster.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MiBandMaster.Import
{
	class Program
	{
		static void Main(string[] args)
		{
			var services = new ServiceCollection();
			var startup = new Startup();
			startup.ConfigureServices(services);
			var provider = services.BuildServiceProvider();
			var loader = new MbmLoader(provider.GetService<MbmContext>());
			var importer = new Importer();
			importer.Import(loader.CreateBodies, provider.GetService<IBodyRepository>());
			importer.Import(loader.CreateActivities, provider.GetService<IActivityRepository>());
			importer.Import(loader.CreateHeartrates, provider.GetService<IHeartrateRepository>());
			importer.Import(loader.CreateSleeps, provider.GetService<ISleepRepository>());
			importer.Import(loader.CreateUsers, provider.GetService<IUserRepository>());
		}
	}
}
