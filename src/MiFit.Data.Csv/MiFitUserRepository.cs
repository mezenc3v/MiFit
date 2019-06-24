using System;
using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data.Csv
{
	public class MiFitUserRepository : IMiFitUserRepository
	{
		private readonly string _csvFilePath;
		private readonly Loader<MiFitUser> _loader = new Loader<MiFitUser>();
		public MiFitUserRepository(string csvFilePath)
		{
			_csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
		}
		public IEnumerable<MiFitUser> GetAll()
		{
			return _loader.Load(_csvFilePath);
		}
	}
}