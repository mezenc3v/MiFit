using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data
{
	public interface IMiFitSleepRepository
	{
		IEnumerable<MiFitSleep> GetAll();
	}
}