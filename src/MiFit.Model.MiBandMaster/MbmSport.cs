using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmSport
	{
		private readonly ISport _sport;

		public MbmSport(ISport sport)
		{
			_sport = sport ?? throw new ArgumentNullException(nameof(sport));
		}

		public string Type { get; set; }
		public string StartTile { get; set; }
		public string SportTime { get; set; }
		public string Distance { get; set; }
		public string MaxPace { get; set; }
		public string MinPace { get; set; }
		public string AvgPage { get; set; }
		public string Calories { get; set; }
	}
}