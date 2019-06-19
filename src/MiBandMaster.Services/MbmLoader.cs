using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiBandMaster.Data;

namespace MiBandMaster.Services
{
	public class MbmLoader
	{
		private readonly IMbmContext _context;
		private static readonly MbmFactory Factory = new MbmFactory();

		public MbmLoader(IMbmContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<User> CreateUsers()
		{
			var users = _context.UserRepository.GetAll();
			return users.Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies()
		{
			var bodies = _context.BodyRepository.GetAll();
			return bodies.Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities()
		{
			var activities = _context.ActivityRepository.GetAll();
			return activities.Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps()
		{
			var sleeps = _context.SleepRepository.GetAll();
			return sleeps.Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates()
		{
			var heartrates = _context.HeartrateRepository.GetAll();
			return heartrates.Select(Factory.Create);
		}
	}
}