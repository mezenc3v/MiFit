using System;
using System.Collections.Generic;
using MiBandMaster.Data;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Loader.SqlLite
{
	public class UserRepository : IUserRepository
	{
		private readonly MbmContext _context;

		public UserRepository(MbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<MbmUser> GetAll()
		{
			return _context.Users;
		}
	}
}