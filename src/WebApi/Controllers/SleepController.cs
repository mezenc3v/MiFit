using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SleepController : ControllerBase
	{
		private readonly ISleepRepository _repo;

		public SleepController(ISleepRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IEnumerable<Sleep> GetAllSleeps()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetSleep")]
		public IActionResult GetSleep(string id)
		{
			Sleep sleep = _repo.Get(id);

			if (sleep == null)
				return NotFound();

			return new ObjectResult(sleep);
		}

		[HttpPost]
		public IActionResult CreateSleep([FromBody] Sleep sleep)
		{
			if (sleep == null)
				return BadRequest();

			Sleep addedSleep = _repo.Create(sleep);
			return CreatedAtRoute("GetSleep", new { id = addedSleep.SleepId.ToLower() }, sleep);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateSleep(string id, [FromBody] Sleep sleep)
		{
			if (sleep == null || !string.Equals(sleep.SleepId, id, StringComparison.OrdinalIgnoreCase))
				return BadRequest();

			_repo.Update(sleep);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSleep(string id)
		{
			var existing = _repo.Get(id);
			if (existing == null)
				return NotFound();

			bool deleted = _repo.Delete(id);
			return deleted 
				? (IActionResult) new NoContentResult() 
				: BadRequest();
		}
	}
}