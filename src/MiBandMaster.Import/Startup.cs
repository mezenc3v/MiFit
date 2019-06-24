using System.IO;
using Data;
using Data.EFCore;
using MiBandMaster.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiBandMaster.Import
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup()
		{
			Configuration = GetConfiguration();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
			var mbmConnectionString = Configuration["ConnectionStrings:MbmConnection"];
			services.AddDbContext<MbmContext>(options => options.UseSqlite(mbmConnectionString));
			services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));
			services.AddScoped<IHeartrateRepository, HeartrateRepository>();
			services.AddScoped<IActivityRepository, ActivityRepository>();
			services.AddScoped<ISleepRepository, SleepRepository>();
			services.AddScoped<IBodyRepository, BodyRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
		}

		private static IConfigurationRoot GetConfiguration()
		{
			return new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile($"appsettings.json", optional: true)
				.Build();
		}
	}
}