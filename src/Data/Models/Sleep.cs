namespace Data.Models
{
	public class Sleep
	{
		public int Id { get; set; }
		public string TimeStamp { get; set; }
		public string Date { get; set; }
		public string LastSyncTime { get; set; }
		public string DeepSleepTime { get; set; }
		public string ShallowSleepTime { get; set; }
		public string WakeTime { get; set; }
		public string Start { get; set; }
		public string Stop { get; set; }
	}
}
