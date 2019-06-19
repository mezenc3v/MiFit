using Data.Models;

namespace MiFit.Services
{
	public class MiFitFactory
	{
		public User Create(Data.Models.User user)
		{
			var createdUser = new User
			{
				Avatar = user.Avatar,
				Birthday = user.Birthday,
				Gender = user.Gender,
				Height = user.Height,
				NickName = user.NickName,
				Weight = user.Weight,
			};
			return createdUser;
		}
		public Activity Create(Data.Models.Activity activity)
		{
			var createdActivity = new Activity
			{
				Calories = activity.Calories,
				Date = activity.Date,
				Distance = activity.Distance,
				LastSyncTime = activity.LastSyncTime,
				RunDistance = activity.RunDistance,
				Steps = activity.Steps,
			};
			return createdActivity;
		}
		public Heartrate Create(Data.Models.Heartrate heartrate)
		{
			var createdHeartrate = new Heartrate
			{
				Date = heartrate.Date,
				LastSyncTime = heartrate.LastSyncTime,
				HeartRate = heartrate.HeartRate,
				TimeStamp = heartrate.TimeStamp,
			};
			return createdHeartrate;
		}
		public Sleep Create(Data.Models.Sleep sleep)
		{
			var createdSleep = new Sleep
			{
				TimeStamp = string.Empty,
				Date = sleep.Date,
				DeepSleepTime = sleep.DeepSleepTime,
				LastSyncTime = sleep.LastSyncTile,
				ShallowSleepTime = sleep.ShallowSleepTime,
				Start = sleep.ShallowSleepTime,
				Stop = sleep.Stop,
				WakeTime = sleep.WakeTime,
			};
			return createdSleep;
		}
		public Body Create(Data.Models.Body body)
		{
			var createdBody = new Body
			{
				Weight = body.Weight,
				VisceralFat = body.VisceralFat,
				Bmi = body.Bmi,
				BodyWaterRate = body.BodyWaterRate,
				BoneMass = body.BoneMass,
				FatRate = body.FatRate,
				Height = body.Height,
				Impedance = body.Impedance,
				Metabolism = body.Metabolism,
				MuscleRate = body.MuscleRate,
				TimeStamp = body.TimeStamp,
			};
			return createdBody;
		}
	}
}