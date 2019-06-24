using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class HeartrateRepository : IHeartrateRepository
	{
		private readonly MbmContext _context;

		public HeartrateRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmHeartrate> GetAll()
		{
			return _context.Heartrates;
		}
	}
}