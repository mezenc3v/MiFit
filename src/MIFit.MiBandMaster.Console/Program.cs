using System;
using System.Linq;
using MiFit.Data.MiBandMaster;
using MiFit.Loader.Csv;

namespace MIFit.MiBandMaster.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				WriteHelp();
				return;
			}

			var config = new Configuration();
			if (string.IsNullOrEmpty(config.ConnectionString))
			{
				System.Console.WriteLine("Database connection string not found");
				return;
			}

			try
			{
				var type = GetType(args[0]);
				Import(args[1], config.ConnectionString, type);
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e);
			}
		}


		private static void Import(string filename, string connectionstring, MeasurementType type)
		{
			var loader = new Loader();
			switch (type)
			{
				case MeasurementType.Body:
					var bodyData = loader.LoadBodyMeasurements(filename).ToList();
					var br = new BodyRepository(connectionstring);
					foreach (var measurement in bodyData)
					{
						br.Add(measurement);
					}
					break;
				case MeasurementType.Activity:
					var activityData = loader.LoadActivityMeasurements(filename).ToList();
					var ar = new ActivityRepository(connectionstring);
					foreach (var measurement in activityData)
					{
						ar.Add(measurement);
					}
					break;
				case MeasurementType.HeartRate:
					var heartrateData = loader.LoadHeartrateMeasurements(filename).ToList();
					var hr = new HeartrateRepository(connectionstring);
					foreach (var measurement in heartrateData)
					{
						hr.Add(measurement);
					}
					break;
				case MeasurementType.Sleep:
					var sleepData = loader.LoadSleepMeasurements(filename).ToList();
					var slr = new SleepRepository(connectionstring);
					foreach (var measurement in sleepData)
					{
						slr.Add(measurement);
					}
					break;
				case MeasurementType.User:
					var userData = loader.LoadUserMeasurements(filename).ToList();
					var ur = new UserRepository(connectionstring);
					foreach (var measurement in userData)
					{
						ur.Add(measurement);
					}
					break;
				case MeasurementType.Sport:
					throw new NotImplementedException(nameof(type));
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		private static void WriteHelp()
		{
			System.Console.WriteLine("Usage: MIFitExporter.MiBandMaster.Console <type> <input csv file>");
			System.Console.WriteLine("Types:");
			System.Console.WriteLine("Body: -b or -body");
			System.Console.WriteLine("Activity: -a or -activity");
			System.Console.WriteLine("Heartrate: -h or -heartrate");
			System.Console.WriteLine("Sleep: -sl or -sleep");
			System.Console.WriteLine("Sport: -sp or -sport");
			System.Console.WriteLine("User: -u or -user");
		}

		private static MeasurementType GetType(string arg)
		{
			switch (arg)
			{
				case "-b":
				case "-body":
					return MeasurementType.Body;
				case "-a":
				case "-activity":
					return MeasurementType.Activity;
				case "-h":
				case "-heartrate":
					return MeasurementType.HeartRate;
				case "-sl":
				case "-sleep":
					return MeasurementType.Sleep;
				case "-sp":
				case "-sport":
					return MeasurementType.Sport;
				case "-u":
				case "-user":
					return MeasurementType.User;
				default:
					throw new ArgumentException($"Not valid type {arg}");
			}
		}
	}
}
