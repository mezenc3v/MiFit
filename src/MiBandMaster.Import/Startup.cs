using System.IO;
using Data;
using Data.EFCore;
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
            var mbmConnectionString  = Configuration["ConnectionStrings:MbmConnection"];
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));
            services.AddSingleton<Data.IMbmContext>(new Loader.SqlLite.ContextImpl(mbmConnectionString));
            services.AddScoped<Data.IHeartrateRepository, Loader.SqlLite.HeartrateRepository>();
            services.AddScoped<Data.IActivityRepository, Loader.SqlLite.ActivityRepository>();
            services.AddScoped<Data.ISleepRepository, Loader.SqlLite.SleepRepository> ();
            services.AddScoped<Data.IBodyRepository, Loader.SqlLite.BodyRepository>();
            services.AddScoped<Data.IUserRepository, Loader.SqlLite.UserRepository>();
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