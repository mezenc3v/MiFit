using System.Collections.Generic;
using Data.Models;

namespace Data.Services.Factory
{
	public interface ISleepFactory
	{
		IEnumerable<Sleep> Create();
	}
}