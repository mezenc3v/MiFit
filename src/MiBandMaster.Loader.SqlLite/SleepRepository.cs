using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class SleepRepository : ISleepRepository
	{
		private readonly string _connection;

		public SleepRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public IEnumerable<MbmSleep> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}