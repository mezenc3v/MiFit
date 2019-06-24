using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiBandMaster.Data;
using MiBandMaster.Loader.SqlLite;

namespace MiBandMaster.Services
{
	public class MbmLoader
	{
		private readonly IUserRepository _userRepository;
		private readonly IHeartrateRepository _heartrateRepository;
		private readonly ISleepRepository _sleepRepository;
		private readonly IActivityRepository _activityRepository;
		private readonly IBodyRepository _bodyRepository;
		private static readonly MbmFactory Factory = new MbmFactory();

		public MbmLoader(MbmContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			_userRepository = new UserRepository(context);
			_heartrateRepository = new HeartrateRepository(context);
			_activityRepository = new ActivityRepository(context);
			_sleepRepository = new SleepRepository(context);
			_bodyRepository = new BodyRepository(context);
		}

		public IEnumerable<User> CreateUsers()
		{
			var users = _userRepository.GetAll();
			return users.Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies()
		{
			var bodies = _bodyRepository.GetAll();
			return bodies.Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities()
		{
			var activities = _activityRepository.GetAll();
			return activities.Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps()
		{
			var sleeps = _sleepRepository.GetAll();
			return sleeps.Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates()
		{
			var heartrates = _heartrateRepository.GetAll();
			return heartrates.Select(Factory.Create);
		}
	}
}