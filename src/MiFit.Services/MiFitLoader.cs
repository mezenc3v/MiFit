using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiFit.Loader.Csv;

namespace MiFit.Services
{
	public class MiFitLoader
	{
		private static readonly MiFitFactory Factory = new MiFitFactory();

		public IEnumerable<User> CreateUsers(string fileName)
		{
			var loader = new Loader<Data.Models.User>();
			return loader.Load(fileName).Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies(string fileName)
		{
			var loader = new Loader<Data.Models.Body>();
			return loader.Load(fileName).Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities(string fileName)
		{
			var loader = new Loader<Data.Models.Activity>();
			return loader.Load(fileName).Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps(string fileName)
		{
			var loader = new Loader<Data.Models.Sleep>();
			return loader.Load(fileName).Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates(string fileName)
		{
			var loader = new Loader<Data.Models.Heartrate>();
			return loader.Load(fileName).Select(Factory.Create);
		}
	}
}