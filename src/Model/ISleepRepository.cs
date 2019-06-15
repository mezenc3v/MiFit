using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
	public interface ISleepRepository
	{
		Sleep Create(Sleep sleep);
		Sleep Get(string id);
		bool Delete(string id);
		Sleep Update(Sleep sleep);
		IEnumerable<Sleep> GetAll();
	}
}
