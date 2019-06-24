using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data.EFCore
{
	public class MbmHeartrateRepository : IMbmHeartrateRepository
	{
		private readonly MbmContext _context;

		public MbmHeartrateRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmHeartrate> GetAll()
		{
			return _context.Heartrates;
		}
	}
}