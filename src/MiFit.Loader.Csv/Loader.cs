using System.Collections.Generic;
using System.IO;
using System.Text;
using MiFit.Loader.Csv.Models;
using MiFit.Model;

namespace MiFit.Loader.Csv
{
	public class Loader : ILoader
	{
		public IEnumerable<IBody> LoadBodyMeasurements(string fileName)
		{
			return ReadFile<BodyRow>(fileName);
		}

		public IEnumerable<IActivity> LoadActivityMeasurements(string fileName)
		{
			return ReadFile<ActivityRow>(fileName);
		}

		public IEnumerable<IHeartrate> LoadHeartrateMeasurements(string fileName)
		{
			return ReadFile<HeartrateRow>(fileName);
		}

		public IEnumerable<ISleep> LoadSleepMeasurements(string fileName)
		{
			return ReadFile<SleepRow>(fileName);
		}

		public IEnumerable<ISport> LoadSportMeasurements(string fileName)
		{
			return ReadFile<SportRow>(fileName);
		}

		public IEnumerable<IUser> LoadUserMeasurements(string fileName)
		{
			return ReadFile<UserRow>(fileName);
		}

		private static IList<string> ReadStrings(string fileName, Encoding encoding)
		{
			var arrBytes = File.ReadAllBytes(fileName);
			var list = new List<string>();
			using (var stream = new MemoryStream(arrBytes))
			using (var reader = new StreamReader(stream, encoding))
			{
				while (!reader.EndOfStream)
					list.Add(reader.ReadLine());
			}
			return list;
		}

		private static IEnumerable<TRow> ReadFile<TRow>(string fileName) where TRow : new()
		{
			
			var rows = ReadStrings(fileName, Encoding.Unicode);
			var list = new List<TRow>();
			var parser = new Parser(rows);
			var factory = new RowFactory<TRow>(parser.Headers);
			for (var cells = parser.ReadLine(); cells != null; cells = parser.ReadLine())
			{
				var row = factory.Create(cells);
				list.Add(row);
			}
			return list;
		}
	}
}