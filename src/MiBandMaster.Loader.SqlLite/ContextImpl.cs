using MiBandMaster.Data;

namespace MiBandMaster.Loader.SqlLite
{
	public class ContextImpl : IMbmContext
	{
		public IHeartrateRepository HeartrateRepository { get; set; }
		public IActivityRepository ActivityRepository { get; set; }
		public ISleepRepository SleepRepository { get; set; }
		public IBodyRepository BodyRepository { get; set; }
		public IUserRepository UserRepository { get; set; }
		

		public ContextImpl(string connectionString)
		{
			HeartrateRepository = new HeartrateRepository(connectionString);
			ActivityRepository = new ActivityRepository(connectionString);
			SleepRepository = new SleepRepository(connectionString);
			BodyRepository = new BodyRepository(connectionString);
			UserRepository = new UserRepository(connectionString);
		}
	}
}