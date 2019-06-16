using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Data.EFCore
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Sleep> Sleeps { get; set; }
		public DbSet<Heartrate> Heartrates { get; set; }
		public DbSet<Body> Bodies { get; set; }
		public DbSet<Activity> Activities { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>().HasKey(u => u.UserId);
			modelBuilder.Entity<Activity>().HasKey(u => u.ActivityId);
			modelBuilder.Entity<Body>().HasKey(u => u.BodyId);
			modelBuilder.Entity<Sleep>().HasKey(u => u.SleepId);
			modelBuilder.Entity<Heartrate>().HasKey(u => u.HeartrateId);
		}
	}
}
