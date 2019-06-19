using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.EFCore
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly ApplicationContext _context;
		private readonly Cache<int, Activity> _cache;
		public ActivityRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_cache = new Cache<int, Activity>(_context.Activities.ToDictionary(a => a.Id));
		}

		public async Task<Activity> CreateAsync(Activity activity)
		{
			var added = _context.Activities.AddAsync(activity);
			int affected = await _context.SaveChangesAsync();
			return affected == 1
				? _cache.AddOrUpdate(activity.Id, activity)
				: null;
		}

		public async Task<Activity> GetAsync(int id)
		{
			return await Task.Run(() =>
			{
				_cache.TryGetValue(id, out var a);
				return a;
			});
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await Task.Run(() =>
			{
				var founded = _context.Activities.Find(id);
				_context.Activities.Remove(founded);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.TryRemove(id, out founded))
					: null;
			});
		}

		public async Task<Activity> UpdateAsync(Activity activity)
		{
			return await Task.Run(() =>
			{
				var updated = _context.Activities.Update(activity);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.UpdateCache(activity.Id, activity))
					: null;
			});
		}

		public async Task<IEnumerable<Activity>> GetAllAsync()
		{
			return await Task.Run<IEnumerable<Activity>>(() => _cache.Values);
		}
	}
}