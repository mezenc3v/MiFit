namespace MiFit.Data.Models
{
	public interface IHeartrate
	{
		string Date { get; }
		string LastSyncTile { get; }
		string HeartRate { get; }
		string TimeStamp { get; }
	}
}