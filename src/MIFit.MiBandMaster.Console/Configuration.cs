using Microsoft.Extensions.Configuration;

namespace MIFit.MiBandMaster.Console
{
	public class Configuration
	{
		public Configuration()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("config.json");
			AppConfiguration = builder.Build();
		}

		public IConfiguration AppConfiguration { get; set; }

		public string ConnectionString => AppConfiguration["connectionString"];
	}
}