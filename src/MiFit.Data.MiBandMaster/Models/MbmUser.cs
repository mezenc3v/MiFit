using System;
using MiFit.Model;

namespace MiFit.Data.MiBandMaster.Models
{
	public class MbmUser
	{
		private readonly IUser _user;

		internal MbmUser(IUser user)
		{
			_user = user ?? throw new ArgumentNullException(nameof(user));
		}
		public string Id { get; set; }
		public string Name => _user.NickName;
		public string Gender => _user.Gender;
		public string Height => _user.Height;
		public string Day { get; set; }
		public string Month => _user.Birthday.Split('-')[1];
		public string Year => _user.Birthday.Split('-')[0];
	}
}