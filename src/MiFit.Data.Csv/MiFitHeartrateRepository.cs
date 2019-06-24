using System;
using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data.Csv
{
	public class MiFitHeartrateRepository : IMiFitHeartrateRepository
	{
		private readonly string _csvFilePath;
		private readonly Loader<MiFitHeartrate> _loader = new Loader<MiFitHeartrate>();
		public MiFitHeartrateRepository(string csvFilePath)
		{
			_csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
		}
		public IEnumerable<MiFitHeartrate> GetAll()
		{
			return _loader.Load(_csvFilePath);
		}
	}
}