using System;
using System.Data.SQLite;
using MiFit.Model;

namespace MiFit.Data.MiBandMaster
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly string _connection;

		public ActivityRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(IActivity activity)
		{
			var measurement = Factory.Create(activity);
			using (var connection = new SQLiteConnection(_connection))
			using (var command = new SQLiteCommand(InsertCmd, connection))
			{
				command.Parameters.AddWithValue("time", measurement.Time);
				command.Parameters.AddWithValue("intensity", measurement.Intensity);
				command.Parameters.AddWithValue("steps", measurement.Steps);
				command.Parameters.AddWithValue("category", measurement.Category);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private const string InsertCmd = @"INSERT INTO [steps]([time],[intensity],[steps],[category]) VALUES (@time,@intensity,@steps,@category);";
	}
}