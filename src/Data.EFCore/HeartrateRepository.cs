using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
	public class HeartrateRepository : IHeartrateRepository
	{
		private readonly ApplicationContext _context;

		public HeartrateRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Heartrate Create(Heartrate heartrate)
		{
			var added = _context.Heartrates.Add(heartrate);
			return added.Entity;
		}

		public Heartrate Get(string id)
		{
			return _context.Heartrates.Find(id);
		}

		public bool Delete(string id)
		{
			var founded = _context.Heartrates.Find(id);
			_context.Heartrates.Remove(founded);
			int affected = _context.SaveChanges();
			return affected == 1;
		}

		public Heartrate Update(Heartrate heartrate)
		{
			var updated = _context.Heartrates.Update(heartrate);
			int affected = _context.SaveChanges();
			return affected == 1 ? updated.Entity : null;
		}

		public IEnumerable<Heartrate> GetAll()
		{
			return _context.Heartrates;
		}
	}
}
