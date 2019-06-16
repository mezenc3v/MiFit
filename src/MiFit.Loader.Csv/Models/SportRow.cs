using MiFit.Data.Models;

namespace MiFit.Loader.Csv.Models
{
	public class SportRow : ISport
	{
		[CsvColumn("type")]
		public string Type { get; set; }
		[CsvColumn("startTime")]
		public string StartTile { get; set; }
		[CsvColumn("sportTime")]
		public string SportTime { get; set; }
		[CsvColumn("distance")]
		public string Distance { get; set; }
		[CsvColumn("maxPace")]
		public string MaxPace { get; set; }
		[CsvColumn("minPace")]
		public string MinPace { get; set; }
		[CsvColumn("avgPace")]
		public string AvgPage { get; set; }
		[CsvColumn("calories")]
		public string Calories { get; set; }
	}
}