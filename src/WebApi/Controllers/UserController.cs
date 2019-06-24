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
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _repo;

		public UserController(IUserRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await _repo.GetAllAsync();
		}

		[HttpGet("{id}", Name = "GetUser")]
		public async Task<IActionResult> GetUser(int id)
		{
			User user = await _repo.GetAsync(id);

			if (user == null)
				return NotFound();

			return new ObjectResult(user);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] User user)
		{
			if (user == null)
				return BadRequest();

			User addedUser = await _repo.CreateAsync(user);
			return CreatedAtRoute("GetUser", new { id = addedUser.Id }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
		{
			if (user == null || user.Id != id)
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
		public async Task<IActionResult> DeleteUser(int id)
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