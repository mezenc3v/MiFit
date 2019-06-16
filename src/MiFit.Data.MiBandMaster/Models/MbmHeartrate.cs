using System;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster.Models
{
	public class MbmHeartrate
	{
		private readonly IHeartrate _heartrate;

		internal MbmHeartrate(IHeartrate heartrate)
		{
			_heartrate = heartrate ?? throw new ArgumentNullException(nameof(heartrate));
		}

		public string Time => _heartrate.Date;
		public string Hr => _heartrate.HeartRate;
	}
}