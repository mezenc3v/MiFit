using System.Collections.Generic;
using Data.Models;

namespace Data.Services.Factory
{
	public interface IHeartrateFactory
	{
		IEnumerable<Heartrate> Create();
	}
}