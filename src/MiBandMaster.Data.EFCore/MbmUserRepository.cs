using System;
using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data.EFCore
{
	public class MbmUserRepository : IMbmUserRepository
	{
		private readonly MbmContext _context;

		public MbmUserRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmUser> GetAll()
		{
			return _context.Users;
		}
	}
}