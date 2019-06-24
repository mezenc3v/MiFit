using System;
using Data;
using Data.Services;
using Microsoft.Extensions.DependencyInjection;
using MiFit.Services;

namespace MiFit.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            var importer = provider.GetService<Importer>();
            var loader = provider.GetService<MiFitLoader>();
            importer.Import(loader.CreateActivities, provider.GetService<IActivityRepository>());
            importer.Import(loader.CreateBodies, provider.GetService<IBodyRepository>());
            importer.Import(loader.CreateHeartrates, provider.GetService<IHeartrateRepository>());
            importer.Import(loader.CreateSleeps, provider.GetService<ISleepRepository>());
            importer.Import(loader.CreateUsers, provider.GetService<IUserRepository>());
        }
    }
}
