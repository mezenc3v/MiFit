using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data.EFCore
{
	public class MbmSleepRepository : IMbmSleepRepository
	{
		private readonly MbmContext _context;

		public MbmSleepRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmSleep> GetAll()
		{
			return _context.Sleeps;
		}
	}
}