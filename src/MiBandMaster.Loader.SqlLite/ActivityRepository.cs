﻿using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class ActivityRepository
	{
		private readonly string _connection;

		public ActivityRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public IEnumerable<MbmActivity> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}