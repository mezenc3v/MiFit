using MiFit.Data.Models;

namespace MiFit.Loader.Csv.Models
{
	public class SleepRow : ISleep
	{
		[CsvColumn("date")]
		public string Date { get; set; }
		[CsvColumn("lastSyncTime")]
		public string LastSyncTile { get; set; }
		[CsvColumn("deepSleepTime")]
		public string DeepSleepTime { get; set; }
		[CsvColumn("shallowSleepTime")]
		public string ShallowSleepTime { get; set; }
		[CsvColumn("wakeTime")]
		public string WakeTime { get; set; }
		[CsvColumn("start")]
		public string Start { get; set; }
		[CsvColumn("stop")]
		public string Stop { get; set; }
	}
}