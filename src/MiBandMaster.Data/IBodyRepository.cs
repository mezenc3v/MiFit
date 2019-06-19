using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data
{
	public interface IBodyRepository
	{
		IEnumerable<MbmBody> GetAll();
	}
}