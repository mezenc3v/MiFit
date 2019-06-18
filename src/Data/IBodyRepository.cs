using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
	public interface IBodyRepository
	{
		Task<Body> CreateAsync(Body body);
		Task<Body> GetAsync(int id);
		Task<bool> DeleteAsync(int id);
		Task<Body> UpdateAsync(Body body);
		Task<IEnumerable<Body>> GetAllAsync();
	}
}
