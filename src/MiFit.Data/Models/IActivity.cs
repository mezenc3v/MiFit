namespace MiFit.Data.Models
{
	public interface IActivity
	{
		string Date { get; }
		string LastSyncTime { get; }
		string Steps { get; }
		string Distance { get; }
		string RunDistance { get; }
		string Calories { get; }
	}
}