using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
	public class BodyRepository : IBodyRepository
	{
		private readonly ApplicationContext _context;

		public BodyRepository(ApplicationContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Body Create(Body body)
		{
			var added = _context.Bodies.Add(body);
			return added.Entity;
		}

		public Body Get(string id)
		{
			return _context.Bodies.Find(id);
		}

		public bool Delete(string id)
		{
			var founded = _context.Bodies.Find(id);
			_context.Bodies.Remove(founded);
			int affected = _context.SaveChanges();
			return affected == 1;
		}

		public Body Update(Body body)
		{
			var updated = _context.Bodies.Update(body);
			int affected = _context.SaveChanges();
			return affected == 1 ? updated.Entity : null;
		}

		public IEnumerable<Body> GetAll()
		{
			return _context.Bodies;
		}
	}
}
