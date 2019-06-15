using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
	public interface IActivityRepository
	{
		Activity Create(Activity activity);
		Activity Get(string id);
		bool Delete(string id);
		Activity Update(Activity activity);
		IEnumerable<Activity> GetAll();
	}
}
