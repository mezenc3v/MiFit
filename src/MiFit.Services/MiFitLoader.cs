using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiFit.Loader.Csv;

namespace MiFit.Services
{
	public class MiFitLoader
	{
        private readonly CsvFiles _files;
        private static readonly MiFitFactory Factory = new MiFitFactory();

        public MiFitLoader(CsvFiles files)
        {
            _files = files ?? throw new ArgumentNullException(nameof(files));
        }

        public IEnumerable<User> CreateUsers()
		{
			var loader = new Loader<Data.Models.User>();
			return loader.Load(_files.UserPath).Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies()
		{
			var loader = new Loader<Data.Models.Body>();
			return loader.Load(_files.BodyPath).Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities()
		{
			var loader = new Loader<Data.Models.Activity>();
			return loader.Load(_files.ActivityPath).Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps()
		{
			var loader = new Loader<Data.Models.Sleep>();
			return loader.Load(_files.SleepPath).Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates()
		{
			var loader = new Loader<Data.Models.Heartrate>();
			return loader.Load(_files.HeartratePath).Select(Factory.Create);
		}
	}
}