using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data.EFCore
{
	public class MbmBodyRepository : IMbmBodyRepository
	{
		private readonly MbmContext _context;

		public MbmBodyRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmBody> GetAll()
		{
			return _context.Bodies;
		}
	}
}