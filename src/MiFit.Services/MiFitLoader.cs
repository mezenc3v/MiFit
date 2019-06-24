using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using MiFit.Data;
using MiFit.Data.Csv;

namespace MiFit.Services
{
	public class MiFitLoader
	{
		private readonly IMiFitUserRepository _userRepository;
		private readonly IMiFitHeartrateRepository _heartrateRepository;
		private readonly IMiFitSleepRepository _sleepRepository;
		private readonly IMiFitActivityRepository _activityRepository;
		private readonly IMiFitBodyRepository _bodyRepository;
		private static readonly MiFitFactory Factory = new MiFitFactory();

		public MiFitLoader(CsvFiles files)
		{
			if (files == null) throw new ArgumentNullException(nameof(files));
			_bodyRepository = new MiFitBodyRepository(files.BodyPath);
			_userRepository = new MiFitUserRepository(files.UserPath);
			_sleepRepository = new MiFitSleepRepository(files.SleepPath);
			_activityRepository = new MiFitActivityRepository(files.ActivityPath);
			_heartrateRepository = new MiFitHeartrateRepository(files.HeartratePath);
		}

		public IEnumerable<User> CreateUsers()
		{
			return _userRepository.GetAll().Select(Factory.Create);
		}

		public IEnumerable<Body> CreateBodies()
		{
			return _bodyRepository.GetAll().Select(Factory.Create);
		}

		public IEnumerable<Activity> CreateActivities()
		{
			return _activityRepository.GetAll().Select(Factory.Create);
		}

		public IEnumerable<Sleep> CreateSleeps()
		{
			return _sleepRepository.GetAll().Select(Factory.Create);
		}

		public IEnumerable<Heartrate> CreateHeartrates()
		{
			return _heartrateRepository.GetAll().Select(Factory.Create);
		}
	}
}