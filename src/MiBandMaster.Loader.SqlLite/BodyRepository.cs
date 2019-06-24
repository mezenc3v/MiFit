using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class BodyRepository : IBodyRepository
	{
		private readonly MbmContext _context;

		public BodyRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmBody> GetAll()
		{
			return _context.Bodies;
		}
	}
}