﻿namespace MiFit.Loader.Csv.Models
{
	public class HeartrateRow
	{
		[CsvColumn("date")]
		public string Date { get; set; }
		[CsvColumn("lastSyncTime")]
		public string LastSyncTile { get; set; }
		[CsvColumn("heartRate")]
		public string HeartRate { get; set; }
		[CsvColumn("timestamp")]
		public string TimeStamp { get; set; }
	}
}