using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;

		public UserRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public User Create(User user)
		{
			var added = _context.Users.Add(user);
			return added.Entity;
		}

		public User Get(string id)
		{
			return _context.Users.Find(id);
		}

		public bool Delete(string id)
		{
			var founded = _context.Users.Find(id);
			_context.Users.Remove(founded);
			int affected = _context.SaveChanges();
			return affected == 1;
		}

		public User Update(User user)
		{
			var updated = _context.Users.Update(user);
			int affected = _context.SaveChanges();
			return affected == 1 ? updated.Entity : null;
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users;
		}
	}
}
