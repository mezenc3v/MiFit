using System;
using System.Data.SQLite;
using MiFit.Model;

namespace MiFit.Data.MiBandMaster
{
	public class HeartrateRepository : IHeartrateRepository
	{
		private readonly string _connection;

		public HeartrateRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(IHeartrate heartrate)
		{
			var measurement = Factory.Create(heartrate);
			using (var connection = new SQLiteConnection(_connection))
			using (var command = new SQLiteCommand(InsertCmd, connection))
			{
				command.Parameters.AddWithValue("time", measurement.Time);
				command.Parameters.AddWithValue("hr", measurement.Hr);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private const string InsertCmd = @"INSERT INTO [heartrate] ([time],[hr]) VALUES (@id,@start_time);";
	}
}