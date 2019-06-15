using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
	public interface IHeartrateRepository
	{
		Heartrate Create(Heartrate heartrate);
		Heartrate Get(string id);
		bool Delete(string id);
		Heartrate Update(Heartrate heartrate);
		IEnumerable<Heartrate> GetAll();
	}
}
