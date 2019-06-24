using Data.Models;

namespace MiFit.Services
{
	public class MiFitFactory
	{
		public User Create(Data.Models.MiFitUser miFitUser)
		{
			var createdUser = new User
			{
				Avatar = miFitUser.Avatar,
				Birthday = miFitUser.Birthday,
				Gender = miFitUser.Gender,
				Height = miFitUser.Height,
				NickName = miFitUser.NickName,
				Weight = miFitUser.Weight,
			};
			return createdUser;
		}
		public Activity Create(Data.Models.MiFitActivity miFitActivity)
		{
			var createdActivity = new Activity
			{
				Calories = miFitActivity.Calories,
				Date = miFitActivity.Date,
				Distance = miFitActivity.Distance,
				LastSyncTime = miFitActivity.LastSyncTime,
				RunDistance = miFitActivity.RunDistance,
				Steps = miFitActivity.Steps,
			};
			return createdActivity;
		}
		public Heartrate Create(Data.Models.MiFitHeartrate miFitHeartrate)
		{
			var createdHeartrate = new Heartrate
			{
				Date = miFitHeartrate.Date,
				LastSyncTime = miFitHeartrate.LastSyncTime,
				HeartRate = miFitHeartrate.HeartRate,
				TimeStamp = miFitHeartrate.TimeStamp,
			};
			return createdHeartrate;
		}
		public Sleep Create(Data.Models.MiFitSleep miFitSleep)
		{
			var createdSleep = new Sleep
			{
				TimeStamp = string.Empty,
				Date = miFitSleep.Date,
				DeepSleepTime = miFitSleep.DeepSleepTime,
				LastSyncTime = miFitSleep.LastSyncTile,
				ShallowSleepTime = miFitSleep.ShallowSleepTime,
				Start = miFitSleep.ShallowSleepTime,
				Stop = miFitSleep.Stop,
				WakeTime = miFitSleep.WakeTime,
			};
			return createdSleep;
		}
		public Body Create(Data.Models.MiFitBody miFitBody)
		{
			var createdBody = new Body
			{
				Weight = miFitBody.Weight,
				VisceralFat = miFitBody.VisceralFat,
				Bmi = miFitBody.Bmi,
				BodyWaterRate = miFitBody.BodyWaterRate,
				BoneMass = miFitBody.BoneMass,
				FatRate = miFitBody.FatRate,
				Height = miFitBody.Height,
				Impedance = miFitBody.Impedance,
				Metabolism = miFitBody.Metabolism,
				MuscleRate = miFitBody.MuscleRate,
				TimeStamp = miFitBody.TimeStamp,
			};
			return createdBody;
		}
	}
}