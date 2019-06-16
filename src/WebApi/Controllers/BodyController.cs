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
	public class BodyController : ControllerBase
	{
		private readonly IBodyRepository _repo;

		public BodyController(IBodyRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IEnumerable<Body> GetAllBodies()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetBody")]
		public IActionResult GetBody(string id)
		{
			Body body = _repo.Get(id);

			if (body == null)
				return NotFound();

			return new ObjectResult(body);
		}

		[HttpPost]
		public IActionResult CreateBody([FromBody] Body body)
		{
			if (body == null)
				return BadRequest();

			Body addedBody = _repo.Create(body);
			return CreatedAtRoute("GetBody", new { id = addedBody.BodyId.ToLower() }, body);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBody(string id, [FromBody] Body body)
		{
			if (body == null || !string.Equals(body.BodyId, id, StringComparison.OrdinalIgnoreCase))
				return BadRequest();

			_repo.Update(body);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBody(string id)
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