﻿using System.Collections.Generic;
using MiBandMaster.Data.Models;

namespace MiBandMaster.Data
{
	public interface ISleepRepository
	{
		IEnumerable<MbmSleep> GetAll();
	}
}