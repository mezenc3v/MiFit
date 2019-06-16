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
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _repo;

		public UserController(IUserRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IEnumerable<User> GetAllUsers()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetUser")]
		public IActionResult GetUser(string id)
		{
			User user = _repo.Get(id);

			if (user == null)
				return NotFound();

			return new ObjectResult(user);
		}

		[HttpPost]
		public IActionResult CreateUser([FromBody] User user)
		{
			if (user == null)
				return BadRequest();

			User addedUser = _repo.Create(user);
			return CreatedAtRoute("GetUser", new { id = addedUser.UserId.ToLower() }, user);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateUser(string id, [FromBody] User user)
		{
			if (user == null || !string.Equals(user.UserId, id, StringComparison.OrdinalIgnoreCase))
				return BadRequest();

			_repo.Update(user);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteUser(string id)
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