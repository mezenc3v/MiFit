namespace MiFit.Data.Models
{
	public interface IBody
	{
		string TimeStamp { get; }
		string Weight { get; }
		string Height { get; }
		string Bmi { get; }
		string FatRate { get; }
		string BodyWaterRate { get; }
		string BoneMass { get; }
		string Metabolism { get; }
		string MuscleRate { get; }
		string VisceralFat { get; }
		string Impedance { get; }
	}
}