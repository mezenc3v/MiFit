
namespace MiFit.Loader.Csv.Models
{
	public partial class BodyRow
	{
		[CsvColumn("timestamp")]
		public string TimeStamp { get; set; }
		[CsvColumn("weight")]
		public string Weight { get; set; }
		[CsvColumn("height")]
		public string Height { get; set; }
		[CsvColumn("bmi")]
		public string Bmi { get; set; }
		[CsvColumn("fatRate")]
		public string FatRate { get; set; }
		[CsvColumn("bodyWaterRate")]
		public string BodyWaterRate { get; set; }
		[CsvColumn("boneMass")]
		public string BoneMass { get; set; }
		[CsvColumn("metabolism")]
		public string Metabolism { get; set; }
		[CsvColumn("muscleRate")]
		public string MuscleRate { get; set; }
		[CsvColumn("visceralFat")]
		public string VisceralFat { get; set; }
		[CsvColumn("impedance")]
		public string Impedance { get; set; }
	}
}