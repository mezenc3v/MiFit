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
		public IEnumerable<Heartrate> GetAllHeartrates()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetHeartrate")]
		public IActionResult GetHeartrate(string id)
		{
			Heartrate heartrate = _repo.Get(id);

			if (heartrate == null)
				return NotFound();

			return new ObjectResult(heartrate);
		}

		[HttpPost]
		public IActionResult CreateHeartrate([FromBody] Heartrate heartrate)
		{
			if (heartrate == null)
				return BadRequest();

			Heartrate addedHeartrate = _repo.Create(heartrate);
			return CreatedAtRoute("GetHeartrate", new { id = addedHeartrate.HeartrateId.ToLower() }, heartrate);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateHeartrate(string id, [FromBody] Heartrate heartrate)
		{
			if (heartrate == null || !string.Equals(heartrate.HeartrateId, id, StringComparison.OrdinalIgnoreCase))
				return BadRequest();

			_repo.Update(heartrate);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteHeartrate(string id)
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