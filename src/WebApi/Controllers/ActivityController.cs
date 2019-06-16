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
	public class ActivityController : ControllerBase
	{
		private readonly IActivityRepository _repo;

		public ActivityController(IActivityRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IEnumerable<Activity> GetAllActivities()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetActivity")]
		public IActionResult GetActivity(string id)
		{
			Activity activity = _repo.Get(id);

			if (activity == null)
				return NotFound();

			return new ObjectResult(activity);
		}

		[HttpPost]
		public IActionResult CreateActivity([FromBody] Activity activity)
		{
			if (activity == null)
				return BadRequest();

			Activity addedActivity = _repo.Create(activity);
			return CreatedAtRoute("GetActivity", new { id = addedActivity.ActivityId.ToLower() }, activity);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateActivity(string id, [FromBody] Activity activity)
		{
			if (activity == null || !string.Equals(activity.ActivityId, id, StringComparison.OrdinalIgnoreCase))
				return BadRequest();

			_repo.Update(activity);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteActivity(string id)
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