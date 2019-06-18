using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
	public interface IHeartrateRepository
	{
		Task<Heartrate> CreateAsync(Heartrate heartrate);
		Task<Heartrate> GetAsync(int id);
		Task<bool> DeleteAsync(int id);
		Task<Heartrate> UpdateAsync(Heartrate heartrate);
		Task<IEnumerable<Heartrate>> GetAllAsync();
	}
}
