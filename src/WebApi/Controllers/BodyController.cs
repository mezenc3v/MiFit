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
		public async Task<IEnumerable<Body>> GetAllBodies()
		{
			return await _repo.GetAllAsync();
		}

		[HttpGet("{id}", Name = "GetBody")]
		public async Task<IActionResult> GetBody(int id)
		{
			Body body = await _repo.GetAsync(id);

			if (body == null)
				return NotFound();

			return new ObjectResult(body);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBody([FromBody] Body body)
		{
			if (body == null)
				return BadRequest();

			Body addedBody = await _repo.CreateAsync(body);
			return CreatedAtRoute("GetBody", new { id = addedBody.Id }, body);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBody(int id, [FromBody] Body body)
		{
			if (body == null || body.Id != id)
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
		public async Task<IActionResult> DeleteBody(int id)
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