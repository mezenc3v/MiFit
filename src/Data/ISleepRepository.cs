using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
	public interface ISleepRepository
	{
		Task<Sleep> CreateAsync(Sleep sleep);
		Task<Sleep> GetAsync(int id);
		Task<bool> DeleteAsync(int id);
		Task<Sleep> UpdateAsync(Sleep sleep);
		Task<IEnumerable<Sleep>> GetAllAsync();
	}
}
