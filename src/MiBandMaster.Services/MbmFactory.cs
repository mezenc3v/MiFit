using System;
using Data.Models;

namespace MiBandMaster.Services
{
	public class MbmFactory
	{
		public User Create(Data.Models.MbmUser user)
		{
			var createdUser = new User
			{
				Avatar = string.Empty,
				Weight = string.Empty,
				Birthday = $"{user.Year}-{user.Month}-{user.Day}",
				Gender = user.Gender,
				Height = user.Height,
				NickName = user.Name,
			};
			return createdUser;
		}
		public Activity Create(Data.Models.MbmActivity activity)
		{
			var createdActivity = new Activity
			{
				Calories = string.Empty,
				Date = string.Empty,
				Distance = string.Empty,
				LastSyncTime = string.Empty,
				RunDistance = string.Empty,
				Steps = activity.Steps,
			};
			return createdActivity;
		}
		public Heartrate Create(Data.Models.MbmHeartrate heartrate)
		{
			var createdHeartrate = new Heartrate
			{
				Date = string.Empty,
				LastSyncTime = string.Empty,
				HeartRate = heartrate.Hr,
				TimeStamp = heartrate.Time,
			};
			return createdHeartrate;
		}
		public Sleep Create(Data.Models.MbmSleep sleep)
		{
			var createdSleep = new Sleep
			{
				Date = string.Empty,
				TimeStamp = string.Empty,
				LastSyncTime = string.Empty,
				DeepSleepTime = sleep.Deep,
				ShallowSleepTime = sleep.Light,
				Start = sleep.StartTime,
				Stop = sleep.EndTime,
				WakeTime = sleep.Awake,
			};
			return createdSleep;
		}
		public Body Create(Data.Models.MbmBody body)
		{
			var createdBody = new Body
			{
				Height = string.Empty,
				Bmi = body.Bmi,
				BodyWaterRate = body.BodyWaterRate,
				BoneMass = body.BoneMass,
				FatRate = body.FatRate,
				Weight = body.Weight,
				Impedance = body.Impedance,
				VisceralFat = body.VisceralFat,
				Metabolism = body.Bmr,
				MuscleRate = body.MuscleRate,
				TimeStamp = body.Time,
			};
			return createdBody;
		}
	}
}