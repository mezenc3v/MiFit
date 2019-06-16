using System;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster.Models
{
	public class MbmSleep
	{
		private readonly ISleep _sleep;

		internal MbmSleep(ISleep sleep)
		{
			_sleep = sleep ?? throw new ArgumentNullException(nameof(sleep));
		}

		public int Id { get; set; }
		public string StartTime => _sleep.Start;
		public string EndTime => _sleep.Stop;
		public string Awake => _sleep.WakeTime;
		public string Deep => _sleep.DeepSleepTime;
		public string Light => _sleep.ShallowSleepTime;
		public string Stages { get; set; }
		public string Deleted { get; set; }
		public string Manually { get; set; }
	}
}