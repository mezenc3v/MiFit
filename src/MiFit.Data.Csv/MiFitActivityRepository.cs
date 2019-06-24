using System;
using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data.Csv
{
	public class MiFitActivityRepository : IMiFitActivityRepository
	{
		private readonly string _csvFilePath;
		private readonly Loader<MiFitActivity> _loader = new Loader<MiFitActivity>();

		public MiFitActivityRepository(string csvFilePath)
		{
			_csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
		}
		public IEnumerable<MiFitActivity> GetAll()
		{
			return _loader.Load(_csvFilePath);
		}
	}
}