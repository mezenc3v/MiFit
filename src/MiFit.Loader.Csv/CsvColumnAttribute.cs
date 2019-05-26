using System;

namespace MiFit.Loader.Csv
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class CsvColumnAttribute : Attribute
	{
		public string Column { get; }

		public CsvColumnAttribute(string column)
		{
			if (string.IsNullOrEmpty(column))
				throw new ArgumentNullException(nameof(column));
			Column = column;
		}
	}
}