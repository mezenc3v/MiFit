using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<IEnumerable<Sleep>> GetAllSleeps()
		{
			return await _repo.GetAllAsync();
		}

		[HttpGet("{id}", Name = "GetSleep")]
		public async Task<IActionResult> GetSleep(int id)
		{
			Sleep sleep = await _repo.GetAsync(id);

			if (sleep == null)
				return NotFound();

			return new ObjectResult(sleep);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSleep([FromBody] Sleep sleep)
		{
			if (sleep == null)
				return BadRequest();

			Sleep addedSleep = await _repo.CreateAsync(sleep);
			return CreatedAtRoute("GetSleep", new { id = addedSleep.Id }, sleep);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSleep(int id, [FromBody] Sleep sleep)
		{
			if (sleep == null || sleep.Id != id)
				return BadRequest();

			var existing = await _repo.GetAsync(id);
			if (existing == null)
			{
				return NotFound();
			}

			await _repo.UpdateAsync(existing);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSleep(int id)
		{
			var existing = await _repo.GetAsync(id);
			if (existing == null)
				return NotFound();

			bool deleted = await _repo.DeleteAsync(id);
			return deleted 
				? (IActionResult) new NoContentResult() 
				: BadRequest();
		}
	}
}