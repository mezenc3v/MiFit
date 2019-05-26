using System;
using System.Data.SQLite;
using MiFit.Model;

namespace MiFit.Data.MiBandMaster
{
	public class SleepRepository : ISleepRepository
	{
		private readonly string _connection;

		public SleepRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(ISleep sleep)
		{
			var measurement = Factory.Create(sleep);
			using (var connection = new SQLiteConnection(_connection))
			using (var command = new SQLiteCommand(InsertCmd, connection))
			{
				command.Parameters.AddWithValue("id", measurement.Id);
				command.Parameters.AddWithValue("start_time", measurement.StartTime);
				command.Parameters.AddWithValue("end_time", measurement.EndTime);
				command.Parameters.AddWithValue("awake", measurement.Awake);
				command.Parameters.AddWithValue("deep", measurement.Deep);
				command.Parameters.AddWithValue("light", measurement.Light);
				command.Parameters.AddWithValue("stages", measurement.Stages);
				command.Parameters.AddWithValue("deleted", measurement.Deleted);
				command.Parameters.AddWithValue("manually", measurement.Manually);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private const string InsertCmd = @"INSERT INTO [sleep]
           ([id]
           ,[start_time]
           ,[end_time]
           ,[awake]
           ,[deep]
           ,[light]
           ,[stages]
           ,[deleted]
           ,[manually])
     VALUES
           (@id,@start_time,@end_time,@awake,@deep,@light,@stages,@deleted,@manually);";
	}
}