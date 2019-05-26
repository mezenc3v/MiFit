using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmSleep
	{
		private readonly ISleep _sleep;

		public MbmSleep(ISleep sleep)
		{
			_sleep = sleep ?? throw new ArgumentNullException(nameof(sleep));
		}

		public int Id { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string Awake { get; set; }
		public string Deep { get; set; }
		public string Light { get; set; }
		public string Stages { get; set; }
		public string Deleted { get; set; }
		public string Manually { get; set; }
	}
}