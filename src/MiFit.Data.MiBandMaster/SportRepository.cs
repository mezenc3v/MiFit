using System;
using MiFit.Model;

namespace MiFit.Data.MiBandMaster
{
	public class SportRepository : ISportRepository
	{
		private readonly string _connection;

		public SportRepository(string connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public void Add(ISport sport)
		{
			throw new System.NotImplementedException();
		}
	}
}