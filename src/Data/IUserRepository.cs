using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
	public interface IUserRepository
	{
		Task<User> CreateAsync(User user);
		Task<User> GetAsync(int id);
		Task<bool> DeleteAsync(int id);
		Task<User> UpdateAsync(User user);
		Task<IEnumerable<User>> GetAllAsync();
	}
}
