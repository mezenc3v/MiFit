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
	public class HeartrateController : ControllerBase
	{
		private readonly IHeartrateRepository _repo;

		public HeartrateController(IHeartrateRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<Heartrate>> GetAllHeartrates()
		{
			return await _repo.GetAllAsync();
		}

		[HttpGet("{id}", Name = "GetHeartrate")]
		public async Task<IActionResult> GetHeartrate(int id)
		{
			Heartrate heartrate = await _repo.GetAsync(id);

			if (heartrate == null)
				return NotFound();

			return new ObjectResult(heartrate);
		}

		[HttpPost]
		public async Task<IActionResult> CreateHeartrate([FromBody] Heartrate heartrate)
		{
			if (heartrate == null)
				return BadRequest();

			Heartrate addedHeartrate = await _repo.CreateAsync(heartrate);
			return CreatedAtRoute("GetHeartrate", new { id = addedHeartrate.Id }, heartrate);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateHeartrate(int id, [FromBody] Heartrate heartrate)
		{
			if (heartrate == null || heartrate.Id != id)
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
		public async Task<IActionResult> DeleteHeartrate(int id)
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