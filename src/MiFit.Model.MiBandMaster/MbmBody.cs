using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmBody
	{
		private readonly IBody _body;
		public MbmBody(IBody measurement)
		{
			_body = measurement ?? throw new ArgumentNullException(nameof(measurement));
		}

		public string TimeStamp => _body.TimeStamp;
		public string Weight => _body.Weight;
		public string Bmi => _body.Bmi;
		public string FatRate => _body.FatRate;
		public string BodyWaterRate => _body.BodyWaterRate;
		public string BoneMass => _body.BoneMass;
		public string MuscleRate => _body.MuscleRate;
		public string VisceralFat => _body.VisceralFat;
		public string Impedance => _body.Impedance;
		public string Bmr => _body.Metabolism;
		public string Profile { get; set; }
		public string MoistureP0 { get; set; }
		public string MoistureP1 { get; set; }
		public string MuscleP0 { get; set; }
		public string MuscleP1 { get; set; }
		public string FatRateP0 { get; set; }
		public string FatRateP1 { get; set; }
		public string FatRateP2 { get; set; }
		public string FatRateP3 { get; set; }
		public string BoneMassP0 { get; set; }
		public string BoneMassP1 { get; set; }
		public string VisceralFatP0 { get; set; }
		public string VisceralFatP1 { get; set; }
		public string BmrP0 { get; set; }
		public string BmiP0 { get; set; }
		public string BmiP1 { get; set; }
		public string BmiP2 { get; set; }
	}
}