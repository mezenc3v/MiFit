using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiFit.Data.Csv
{
	public class Loader<TRow> where TRow : new()
	{
		public IEnumerable<TRow> Load(string fileName)
		{
			return ReadFile(fileName);
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

		private static IEnumerable<TRow> ReadFile(string fileName)
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