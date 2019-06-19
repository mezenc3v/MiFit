using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class HeartrateRepository : IHeartrateRepository
	{
		private readonly string _connection;

		public HeartrateRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public IEnumerable<MbmHeartrate> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}