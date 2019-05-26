namespace MiFit.Model
{
	public interface ISport
	{
		string Type { get; }
		string StartTile { get; }
		string SportTime { get; }
		string Distance { get; }
		string MaxPace { get; }
		string MinPace { get; }
		string AvgPage { get; }
		string Calories { get; }
	}
}