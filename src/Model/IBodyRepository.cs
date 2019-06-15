using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
	public interface IBodyRepository
	{
		Body Create(Body body);
		Body Get(string id);
		bool Delete(string id);
		Body Update(Body body);
		IEnumerable<Body> GetAll();
	}
}
