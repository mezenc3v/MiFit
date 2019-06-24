using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiBandMaster.Data;
using MiBandMaster.Data.EFCore;

namespace MiBandMaster.Services
{
	public class MbmLoader
	{
		private readonly IMbmUserRepository _mbmUserRepository;
		private readonly IMbmHeartrateRepository _mbmHeartrateRepository;
		private readonly IMbmSleepRepository _mbmSleepRepository;
		private readonly IMbmActivityRepository _mbmActivityRepository;
		private readonly IMbmBodyRepository _mbmBodyRepository;
		private static readonly MbmFactory Factory = new MbmFactory();

		public MbmLoader(MbmContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			_mbmUserRepository = new MbmUserRepository(context);
			_mbmHeartrateRepository = new MbmHeartrateRepository(context);
			_mbmActivityRepository = new MbmActivityRepository(context);
			_mbmSleepRepository = new MbmSleepRepository(context);
			_mbmBodyRepository = new MbmBodyRepository(context);
		}

		public IEnumerable<User> CreateUsers()
		{
			var users = _mbmUserRepository.GetAll();
			return users.Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies()
		{
			var bodies = _mbmBodyRepository.GetAll();
			return bodies.Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities()
		{
			var activities = _mbmActivityRepository.GetAll();
			return activities.Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps()
		{
			var sleeps = _mbmSleepRepository.GetAll();
			return sleeps.Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates()
		{
			var heartrates = _mbmHeartrateRepository.GetAll();
			return heartrates.Select(Factory.Create);
		}
	}
}