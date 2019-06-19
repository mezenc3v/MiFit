using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.EFCore
{
	public class HeartrateRepository : IHeartrateRepository
	{
		private readonly ApplicationContext _context;
		private readonly Cache<int, Heartrate> _cache;
		public HeartrateRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_cache = new Cache<int, Heartrate>(_context.Heartrates.ToDictionary(u => u.Id));
		}

		public async Task<Heartrate> CreateAsync(Heartrate heartrate)
		{
			var added = _context.Heartrates.AddAsync(heartrate);
			int affected = await _context.SaveChangesAsync();
			return affected == 1
				? _cache.AddOrUpdate(heartrate.Id, heartrate)
				: null;
		}

		public async Task<Heartrate> GetAsync(int id)
		{
			return await Task.Run(() =>
			{
				_cache.TryGetValue(id, out var h);
				return h;
			});
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await Task.Run(() =>
			{
				var founded = _context.Heartrates.Find(id);
				_context.Heartrates.Remove(founded);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.TryRemove(id, out founded))
					: null;
			});
		}

		public async Task<Heartrate> UpdateAsync(Heartrate heartrate)
		{
			return await Task.Run(() =>
			{
				var updated = _context.Heartrates.Update(heartrate);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.UpdateCache(heartrate.Id, heartrate))
					: null;
			});
		}

		public async Task<IEnumerable<Heartrate>> GetAllAsync()
		{
			return await Task.Run<IEnumerable<Heartrate>>(() => _cache.Values);
		}
	}
}