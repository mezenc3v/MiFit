using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
	public interface IActivityRepository
	{
		Task<Activity> CreateAsync(Activity activity);
		Task<Activity> GetAsync(int id);
		Task<bool> DeleteAsync(int id);
		Task<Activity> UpdateAsync(Activity activity);
		Task<IEnumerable<Activity>> GetAllAsync();
	}
}
