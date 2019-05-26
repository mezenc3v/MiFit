using System;

namespace MiFitExporter.Model.MiBandMaster
{
	public class MbmUser
	{
		private readonly IUser _user;

		public MbmUser(IUser user)
		{
			_user = user ?? throw new ArgumentNullException(nameof(user));
		}
		public string UserId { get; set; }
		public string Gender { get; set; }
		public string Height { get; set; }
		public string Weight { get; set; }
		public string NickName { get; set; }
		public string Avatar { get; set; }
		public string Birthday { get; set; }
	}
}