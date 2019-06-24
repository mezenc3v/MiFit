using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data
{
	public interface IMbmBodyRepository
	{
		IEnumerable<MbmBody> GetAll();
	}
}