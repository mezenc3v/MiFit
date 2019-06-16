using MiFit.Data.Models;

namespace MiFit.Loader.Csv.Models
{
	public class ActivityRow : IActivity
	{
		[CsvColumn("date")]
		public string Date { get; set; }
		[CsvColumn("lastSyncTime")]
		public string LastSyncTime { get; set; }
		[CsvColumn("steps")]
		public string Steps { get; set; }
		[CsvColumn("distance")]
		public string Distance { get; set; }
		[CsvColumn("runDistance")]
		public string RunDistance { get; set; }
		[CsvColumn("calories")]
		public string Calories { get; set; }
	}
}