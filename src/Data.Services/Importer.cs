using System;
using System.Collections.Generic;
using Data.Models;

namespace Data.Services
{
	public class Importer
	{
		public void Import(Func<IEnumerable<Body>> func, IBodyRepository repo)
		{
			foreach (var body in func.Invoke())
			{
				repo.CreateAsync(body);
			}
		}
		public void Import(Func<IEnumerable<User>> func, IUserRepository repo)
		{
			foreach (var user in func.Invoke())
			{
				repo.CreateAsync(user);
			}
		}
		public void Import(Func<IEnumerable<Activity>> func, IActivityRepository repo)
		{
			foreach (var activity in func.Invoke())
			{
				repo.CreateAsync(activity);
			}
		}
		public void Import(Func<IEnumerable<Sleep>> func, ISleepRepository repo)
		{
			foreach (var sleep in func.Invoke())
			{
				repo.CreateAsync(sleep);
			}
		}
		public void Import(Func<IEnumerable<Heartrate>> func, IHeartrateRepository repo)
		{
			foreach (var heartrate in func.Invoke())
			{
				repo.CreateAsync(heartrate);
			}
		}
	}
}