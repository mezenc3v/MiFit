using System;
using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data.Csv
{
	public class MiFitBodyRepository : IMiFitBodyRepository
	{
		private readonly string _csvFilePath;
		private readonly Loader<MiFitBody> _loader = new Loader<MiFitBody>();
		public MiFitBodyRepository(string csvFilePath)
		{
			_csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
		}
		public IEnumerable<MiFitBody> GetAll()
		{
			return _loader.Load(_csvFilePath);
		}
	}
}