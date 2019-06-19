using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.EFCore
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		private readonly Cache<int, User> _cache;
		public UserRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_cache = new Cache<int, User>(_context.Users.ToDictionary(u => u.Id));
		}

		public async Task<User> CreateAsync(User user)
		{
			var added = _context.Users.AddAsync(user);
			int affected = await _context.SaveChangesAsync();
			return affected == 1 
				? _cache.AddOrUpdate(user.Id, user) 
				: null;
		}

		public async Task<User> GetAsync(int id)
		{
			return await Task.Run(() =>
			{
				_cache.TryGetValue(id, out var u);
				return u;
			}); 
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await Task.Run(() =>
			{
				var founded = _context.Users.Find(id);
				_context.Users.Remove(founded);
				int affected = _context.SaveChanges();
				return affected == 1 
					? Task.Run(() => _cache.TryRemove(id, out founded)) 
					: null;
			});
		}

		public async Task<User> UpdateAsync(User user)
		{
			return await Task.Run(() =>
			{
				var updated = _context.Users.Update(user);
				int affected = _context.SaveChanges();
				return affected == 1 
					? Task.Run(() => _cache.UpdateCache(user.Id, user)) 
					: null;
			});
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await Task.Run<IEnumerable<User>>(() => _cache.Values);
		}
	}
}
