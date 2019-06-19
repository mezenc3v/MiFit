using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.EFCore
{
	public class BodyRepository : IBodyRepository
	{
		private readonly ApplicationContext _context;
		private readonly Cache<int, Body> _cache;
		public BodyRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_cache = new Cache<int, Body>(_context.Bodies.ToDictionary(b => b.Id));
		}

		public async Task<Body> CreateAsync(Body body)
		{
			var added = _context.Bodies.AddAsync(body);
			int affected = await _context.SaveChangesAsync();
			return affected == 1
				? _cache.AddOrUpdate(body.Id, body)
				: null;
		}

		public async Task<Body> GetAsync(int id)
		{
			return await Task.Run(() =>
			{
				_cache.TryGetValue(id, out var b);
				return b;
			});
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await Task.Run(() =>
			{
				var founded = _context.Bodies.Find(id);
				_context.Bodies.Remove(founded);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.TryRemove(id, out founded))
					: null;
			});
		}

		public async Task<Body> UpdateAsync(Body body)
		{
			return await Task.Run(() =>
			{
				var updated = _context.Bodies.Update(body);
				int affected = _context.SaveChanges();
				return affected == 1
					? Task.Run(() => _cache.UpdateCache(body.Id, body))
					: null;
			});
		}

		public async Task<IEnumerable<Body>> GetAllAsync()
		{
			return await Task.Run<IEnumerable<Body>>(() => _cache.Values);
		}
	}
}