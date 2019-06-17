using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.EFCore
{
	public class SleepRepository : ISleepRepository
	{
		private readonly ApplicationContext _context;
		private readonly Cache<int, Sleep> _cache;
		public SleepRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_cache = new Cache<int, Sleep>(_context.Sleeps.ToDictionary(s => s.Id));
		}

		public async Task<Sleep> CreateAsync(Sleep sleep)
		{
			var added = _context.Sleeps.AddAsync(sleep);
			int affected = await _context.SaveChangesAsync();
			return affected == 1
				? _cache.AddOrUpdate(sleep.Id, sleep)
				: null;
		}

		public async Task<Sleep> GetAsync(int id)
		{
			return await Task.Run(() =>
			{
				_cache.TryGetValue(id, out var s);
				return s;
			});
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await Task.Run(() =>
			{
				var founded = _context.Sleeps.Find(id);
				_context.Sleeps.Remove(founded);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.TryRemove(id, out founded))
					: null;
			});
		}

		public async Task<Sleep> UpdateAsync(Sleep sleep)
		{
			return await Task.Run(() =>
			{
				var updated = _context.Sleeps.Update(sleep);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.UpdateCache(sleep.Id, sleep))
					: null;
			});
		}

		public async Task<IEnumerable<Sleep>> GetAllAsync()
		{
			return await Task.Run<IEnumerable<Sleep>>(() => _cache.Values);
		}
	}
}