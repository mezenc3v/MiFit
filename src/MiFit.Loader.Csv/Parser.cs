using System;
using System.Collections.Generic;

namespace MiFit.Loader.Csv
{
	public class Parser
	{
		private readonly char[] _splitter = { ',' };

		private readonly IList<string> _lines;

		public string[] Headers { get; }
		public int LineNumber { get; private set; }

		public Parser(IList<string> lines)
		{
			_lines = lines ?? throw new ArgumentNullException(nameof(lines));
			LineNumber = 0;

			var line = _lines[LineNumber++];
			if (line == null)
				throw new ArgumentException("First line in stream is empty");
			Headers = line.Split(_splitter);
		}

		public string[] ReadLine()
		{
			string[] row = ReadLineImpl();
			if (row == null)
				return null;
			if (row.Length != Headers.Length)
				throw new FormatException($"Invalid row {LineNumber}");
			return row;
		}

		private string[] ReadLineImpl()
		{
			string line;
			do
			{
				if (LineNumber == _lines.Count)
					return null;
				line = _lines[LineNumber++];
				if (line == null)
					return null;
				line = line.Trim();
			}
			while (line == string.Empty);
			return line.Split(_splitter);
		}
	}
}