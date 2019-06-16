namespace MiFit.Data.Models
{
	public interface ISleep
	{
		string Date { get; }
		string LastSyncTile { get; }
		string DeepSleepTime { get; }
		string ShallowSleepTime { get; }
		string WakeTime { get; }
		string Start { get; }
		string Stop { get; }
	}
}