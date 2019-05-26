using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MiFit.Loader.Csv
{
	public class RowFactory<TRow> where TRow : new()
	{
		private readonly Dictionary<int, PropertyInfo> _map = new Dictionary<int, PropertyInfo>();
		private readonly string[] _headers;

		public RowFactory(string[] headers)
		{
			_headers = headers;
			var props = from p in typeof(TRow).GetProperties()
				let attrs = p.GetCustomAttributes(typeof(CsvColumnAttribute), true)
				from attr in attrs
				where attr is CsvColumnAttribute
				select new { Property = p, Attribute = attr as CsvColumnAttribute };

			foreach (var prop in props)
			{
				int pos = Array.IndexOf(headers, prop.Attribute.Column);
				if (pos >= 0)
				{
					_map.Add(pos, prop.Property);
				}
				else
				{
					throw new FormatException($"Invalid header. Missing column '{prop.Attribute.Column}'.");
				}
			}
		}

		public TRow Create(string[] row)
		{
			var newRow = new TRow();
			foreach (var map in _map)
			{
				try
				{
					var prop = map.Value;
					var value = Convert.ChangeType(row[map.Key], prop.PropertyType);
					prop.SetValue(newRow, value, null);
				}
				catch (Exception e)
				{
					throw new FormatException($"Cannot parse {_headers[map.Key]}", e);
				}
			}
			return newRow;
		}
	}
}