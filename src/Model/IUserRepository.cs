using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data
{
	public interface IUserRepository
	{
		User Create(User user);
		User Get(string id);
		bool Delete(string id);
		User Update(User user);
		IEnumerable<User> GetAll();
	}
}
