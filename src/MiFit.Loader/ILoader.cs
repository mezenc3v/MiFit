using System.Collections.Generic;
using MiFit.Model;

namespace MiFit.Loader
{
	public interface ILoader
	{
		IEnumerable<IBody> LoadBodyMeasurements(string fileName);
		IEnumerable<IActivity> LoadActivityMeasurements(string fileName);
		IEnumerable<IHeartrate> LoadHeartrateMeasurements(string fileName);
		IEnumerable<ISleep> LoadSleepMeasurements(string fileName);
		IEnumerable<ISport> LoadSportMeasurements(string fileName);
		IEnumerable<IUser> LoadUserMeasurements(string fileName);
	}
}