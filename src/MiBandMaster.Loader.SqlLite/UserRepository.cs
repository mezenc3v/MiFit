using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class UserRepository : IUserRepository
	{
		private readonly string _connection;

		public UserRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public IEnumerable<MbmUser> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}