using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data.EFCore
{
	public class MbmActivityRepository : IMbmActivityRepository
	{
		private readonly MbmContext _context;

		public MbmActivityRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmActivity> GetAll()
		{
			return _context.Activities;
		}
	}
}