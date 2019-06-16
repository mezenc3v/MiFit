using System;
using System.Data.SQLite;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster
{
	public class BodyRepository : IBodyRepository
	{
		private readonly string _connection;

		public BodyRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(IBody body)
		{
			var measurement = Factory.Create(body);
			using (var connection = new SQLiteConnection(_connection))
			using (var command = new SQLiteCommand(InsertCmd, connection))
			{
				command.Parameters.AddWithValue("time", measurement.TimeStamp);
				command.Parameters.AddWithValue("profile", measurement.Profile);
				command.Parameters.AddWithValue("weight", measurement.Weight);
				command.Parameters.AddWithValue("impedance", measurement.Impedance);
				command.Parameters.AddWithValue("moisture", measurement.BodyWaterRate);
				command.Parameters.AddWithValue("moisture_p0", measurement.MoistureP0);
				command.Parameters.AddWithValue("moisture_p1", measurement.MoistureP1);
				command.Parameters.AddWithValue("muscle", measurement.MuscleRate);
				command.Parameters.AddWithValue("muscle_p0", measurement.MuscleP0);
				command.Parameters.AddWithValue("muscle_p1", measurement.MuscleP1);
				command.Parameters.AddWithValue("fat_rate", measurement.FatRate);
				command.Parameters.AddWithValue("fat_rate_p0", measurement.FatRateP0);
				command.Parameters.AddWithValue("fat_rate_p1", measurement.FatRateP1);
				command.Parameters.AddWithValue("fat_rate_p2", measurement.FatRateP2);
				command.Parameters.AddWithValue("fat_rate_p3", measurement.FatRateP3);
				command.Parameters.AddWithValue("bone_mass", measurement.BoneMass);
				command.Parameters.AddWithValue("bone_mass_p0", measurement.BoneMassP0);
				command.Parameters.AddWithValue("bone_mass_p1", measurement.BoneMassP1);
				command.Parameters.AddWithValue("visceral_fat", measurement.VisceralFat);
				command.Parameters.AddWithValue("visceral_fat_p0", measurement.VisceralFatP0);
				command.Parameters.AddWithValue("visceral_fat_p1", measurement.VisceralFatP1);
				command.Parameters.AddWithValue("bmr", measurement.Bmr);
				command.Parameters.AddWithValue("bmr_p0", measurement.BmrP0);
				command.Parameters.AddWithValue("bmi", measurement.Bmi);
				command.Parameters.AddWithValue("bmi_p0", measurement.BmiP0);
				command.Parameters.AddWithValue("bmi_p1", measurement.BmiP1);
				command.Parameters.AddWithValue("bmi_p2", measurement.BmiP2);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private const string InsertCmd = @"INSERT INTO [weight]
					([time],[profile],[weight],[impedance],[moisture],[moisture_p0],[moisture_p1],[muscle],[muscle_p0],[muscle_p1],[fat_rate]
				,[fat_rate_p0],[fat_rate_p1],[fat_rate_p2],[fat_rate_p3],[bone_mass],[bone_mass_p0],[bone_mass_p1],[visceral_fat]
				,[visceral_fat_p0],[visceral_fat_p1],[bmr],[bmr_p0],[bmi],[bmi_p0],[bmi_p1],[bmi_p2])
			VALUES
				(@time,@profile,@weight,@impedance,@moisture,@moisture_p0,@moisture_p1,@muscle,@muscle_p0,@muscle_p1
,@fat_rate,@fat_rate_p0,@fat_rate_p1,@fat_rate_p2,@fat_rate_p3,@bone_mass,@bone_mass_p0,@bone_mass_p1,
@visceral_fat,@visceral_fat_p0,@visceral_fat_p1,@bmr,@bmr_p0,@bmi,@bmi_p0,@bmi_p1,@bmi_p2);";
	}
}