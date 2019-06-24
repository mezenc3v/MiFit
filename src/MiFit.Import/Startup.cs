using System.IO;
using Data;
using Data.EFCore;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiFit.Services;

namespace MiFit.Import
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
			var files = new CsvFiles
			{
				UserPath = Configuration["CsvFiles:User"],
				ActivityPath = Configuration["CsvFiles:Activity"],
				SleepPath = Configuration["CsvFiles:Sleep"],
				HeartratePath = Configuration["CsvFiles:Heartrate"],
				BodyPath = Configuration["CsvFiles:Body"],
			};
			services.AddSingleton<MiFitLoader>(new MiFitLoader(files));
			services.AddSingleton<Importer>(new Importer());
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