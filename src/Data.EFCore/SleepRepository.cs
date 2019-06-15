using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
	public class SleepRepository : ISleepRepository
	{
		private readonly ApplicationContext _context;

		public SleepRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Sleep Create(Sleep sleep)
		{
			var added = _context.Sleeps.Add(sleep);
			return added.Entity;
		}

		public Sleep Get(string id)
		{
			return _context.Sleeps.Find(id);
		}

		public bool Delete(string id)
		{
			var founded = _context.Sleeps.Find(id);
			_context.Sleeps.Remove(founded);
			int affected = _context.SaveChanges();
			return affected == 1;
		}

		public Sleep Update(Sleep sleep)
		{
			var updated = _context.Sleeps.Update(sleep);
			int affected = _context.SaveChanges();
			return affected == 1 ? updated.Entity : null;
		}

		public IEnumerable<Sleep> GetAll()
		{
			return _context.Sleeps;
		}
	}
}
