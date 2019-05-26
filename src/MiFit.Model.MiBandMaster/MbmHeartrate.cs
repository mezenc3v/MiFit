using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmHeartrate
	{
		private readonly IHeartrate _heartrate;

		public MbmHeartrate(IHeartrate heartrate)
		{
			_heartrate = heartrate ?? throw new ArgumentNullException(nameof(heartrate));
		}

		public string Date { get; set; }
		public string LastSyncTile { get; set; }
		public string HeartRate { get; set; }
		public string TimeStamp { get; set; }
	}
}