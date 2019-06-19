namespace MiBandMaster.Data
{
	public interface IMbmContext
	{
		IActivityRepository ActivityRepository { get; set; }
		IBodyRepository BodyRepository { get; set; }
		IHeartrateRepository HeartrateRepository { get; set; }
		IUserRepository UserRepository { get; set; }
		ISleepRepository SleepRepository { get; set; }
	}
}