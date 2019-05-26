using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmActivity
	{
		private readonly IActivity _activity;
		public MbmActivity(IActivity measurement)
		{
			_activity = measurement ?? throw new ArgumentNullException(nameof(measurement));
		}

		public string Date { get; set; }
		public string LastSyncTime { get; set; }
		public string Steps { get; set; }
		public string Distance { get; set; }
		public string RunDistance { get; set; }
		public string Calories { get; set; }
	}
}