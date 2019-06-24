using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly MbmContext _context;

		public ActivityRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmActivity> GetAll()
		{
			return _context.Activities;
		}
	}
}