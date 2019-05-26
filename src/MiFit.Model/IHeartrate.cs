namespace MiFit.Model
{
	public interface IHeartrate
	{
		string Date { get; }
		string LastSyncTile { get; }
		string HeartRate { get; }
		string TimeStamp { get; }
	}
}