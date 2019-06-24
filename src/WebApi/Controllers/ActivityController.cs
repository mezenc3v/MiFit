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
	public class ActivityController : ControllerBase
	{
		private readonly IActivityRepository _repo;

		public ActivityController(IActivityRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<Activity>> GetAllActivities()
		{
			return await _repo.GetAllAsync();
		}

		[HttpGet("{id}", Name = "GetActivity")]
		public async Task<IActionResult> GetActivity(int id)
		{
			Activity activity = await _repo.GetAsync(id);

			if (activity == null)
				return NotFound();

			return new ObjectResult(activity);
		}

		[HttpPost]
		public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
		{
			if (activity == null)
				return BadRequest();

			Activity addedActivity = await _repo.CreateAsync(activity);
			return CreatedAtRoute("GetActivity", new { id = addedActivity.Id }, activity);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
		{
			if (activity == null || activity.Id != id)
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
		public async Task<IActionResult> DeleteActivity(int id)
		{
			var existing = _repo.GetAsync(id);
			if (existing == null)
				return NotFound();

			bool deleted = await _repo.DeleteAsync(id);
			return deleted 
				? (IActionResult) new NoContentResult() 
				: BadRequest();
		}
	}
}