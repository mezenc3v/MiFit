using System;
using System.Data.SQLite;
using MiFit.Data.Models;

namespace MiFit.Data.MiBandMaster
{
	public class UserRepository : IUserRepository
	{
		private readonly string _connection;

		public UserRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(IUser user)
		{
			var measurement = Factory.Create(user);
			using (var connection = new SQLiteConnection(_connection))
			using (var command = new SQLiteCommand(InsertCmd, connection))
			{
				command.Parameters.AddWithValue("id", measurement.Id);
				command.Parameters.AddWithValue("name", measurement.Name);
				command.Parameters.AddWithValue("gender", measurement.Gender);
				command.Parameters.AddWithValue("height", measurement.Height);
				command.Parameters.AddWithValue("day", measurement.Day);
				command.Parameters.AddWithValue("month", measurement.Month);
				command.Parameters.AddWithValue("year", measurement.Year);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private const string InsertCmd = @"INSERT INTO [weight_profile]([id],[name],[gender],[height],[day],[month],[year]) 
												VALUES (@id,@name,@gender,@height,@day,@month,@year);";
	}
}