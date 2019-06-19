using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data
{
	public interface IActivityRepository
	{
		IEnumerable<MbmActivity> GetAll();
	}
}