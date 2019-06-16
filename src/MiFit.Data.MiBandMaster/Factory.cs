using MiFit.Data.MiBandMaster.Models;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster
{
	public class Factory
	{
		public static MbmBody Create(IBody measurement)
		{
			return new MbmBody(measurement);
		}

		public static MbmHeartrate Create(IHeartrate measurement)
		{
			return new MbmHeartrate(measurement);
		}

		public static MbmUser Create(IUser measurement)
		{
			return new MbmUser(measurement);
		}

		public static MbmSleep Create(ISleep measurement)
		{
			return new MbmSleep(measurement);
		}

		public static MbmActivity Create(IActivity measurement)
		{
			return new MbmActivity(measurement);
		}
	}
}