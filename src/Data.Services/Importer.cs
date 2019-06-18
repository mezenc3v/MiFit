using Data.Services.Factory;

namespace Data.Services
{
	public class Importer
	{
		public void Import(IBodyFactory factory, IBodyRepository repo)
		{
			foreach (var body in factory.Create())
			{
				repo.CreateAsync(body);
			}
		}
		public void Import(IUserFactory factory, IUserRepository repo)
		{
			foreach (var user in factory.Create())
			{
				repo.CreateAsync(user);
			}
		}
		public void Import(IActivityFactory factory, IActivityRepository repo)
		{
			foreach (var activity in factory.Create())
			{
				repo.CreateAsync(activity);
			}
		}
		public void Import(ISleepFactory factory, ISleepRepository repo)
		{
			foreach (var sleep in factory.Create())
			{
				repo.CreateAsync(sleep);
			}
		}
		public void Import(IHeartrateFactory factory, IHeartrateRepository repo)
		{
			foreach (var heartrate in factory.Create())
			{
				repo.CreateAsync(heartrate);
			}
		}
	}
}