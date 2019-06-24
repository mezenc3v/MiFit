using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class SleepRepository : ISleepRepository
	{
		private readonly MbmContext _context;

		public SleepRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmSleep> GetAll()
		{
			return _context.Sleeps;
		}
	}
}