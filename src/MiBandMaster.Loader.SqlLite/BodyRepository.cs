﻿using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class BodyRepository
	{
		private readonly string _connection;

		public BodyRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public IEnumerable<MbmBody> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}