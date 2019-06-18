using System.Collections.Generic;
using Data.Models;

namespace Data.Services.Factory
{
	public interface IActivityFactory
	{
		IEnumerable<Activity> Create();
	}
}