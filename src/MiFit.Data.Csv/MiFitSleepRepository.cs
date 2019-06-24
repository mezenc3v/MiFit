using System;
using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data.Csv
{
	public class MiFitSleepRepository : IMiFitSleepRepository
	{
		private readonly string _csvFilePath;
		private readonly Loader<MiFitSleep> _loader = new Loader<MiFitSleep>();
		public MiFitSleepRepository(string csvFilePath)
		{
			_csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
		}
		public IEnumerable<MiFitSleep> GetAll()
		{
			return _loader.Load(_csvFilePath);
		}
	}
}