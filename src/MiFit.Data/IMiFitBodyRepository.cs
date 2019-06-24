using System.Collections.Generic;
using MiFit.Data.Models;

namespace MiFit.Data
{
	public interface IMiFitBodyRepository
	{
		IEnumerable<MiFitBody> GetAll();
	}
}