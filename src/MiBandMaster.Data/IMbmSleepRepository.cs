using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data
{
	public interface IMbmSleepRepository
	{
		IEnumerable<MbmSleep> GetAll();
	}
}