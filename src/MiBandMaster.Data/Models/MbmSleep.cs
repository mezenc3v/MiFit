namespace MiBandMaster.Data.Models
{
	public class MbmSleep
	{
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