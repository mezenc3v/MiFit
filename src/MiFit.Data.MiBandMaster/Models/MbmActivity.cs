using System;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster.Models
{
	public class MbmActivity
	{
		private readonly IActivity _activity;
		internal MbmActivity(IActivity measurement)
		{
			_activity = measurement ?? throw new ArgumentNullException(nameof(measurement));
		}

		public string Time => _activity.LastSyncTime;
		public string Intensity { get; set; }
		public string Steps => _activity.Steps;
		public string Category { get; set; }
	}
}