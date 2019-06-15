using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly ApplicationContext _context;

		public ActivityRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Activity Create(Activity activity)
		{
			var added = _context.Activities.Add(activity);
			return added.Entity;
		}

		public Activity Get(string id)
		{
			return _context.Activities.Find(id);
		}

		public bool Delete(string id)
		{
			var founded = _context.Activities.Find(id);
			_context.Activities.Remove(founded);
			int affected = _context.SaveChanges();
			return affected == 1;
		}

		public Activity Update(Activity activity)
		{
			var updated = _context.Activities.Update(activity);
			int affected = _context.SaveChanges();
			return affected == 1 ? updated.Entity : null;
		}

		public IEnumerable<Activity> GetAll()
		{
			return _context.Activities;
		}
	}
}
