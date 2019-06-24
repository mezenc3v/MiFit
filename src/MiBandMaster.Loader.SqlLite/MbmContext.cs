using MiBandMaster.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MiBandMaster.Loader.SqlLite
{
	public class MbmContext : DbContext
	{
		public DbSet<MbmUser> Users { get; set; }
		public DbSet<MbmSleep> Sleeps { get; set; }
		public DbSet<MbmHeartrate> Heartrates { get; set; }
		public DbSet<MbmBody> Bodies { get; set; }
		public DbSet<MbmActivity> Activities { get; set; }

		public MbmContext(DbContextOptions<MbmContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<MbmUser>().ToTable("weight_profile").HasKey(u => u.Id);
			modelBuilder.Entity<MbmActivity>().ToTable("steps").HasKey(u => u.Time);
			modelBuilder.Entity<MbmBody>().ToTable("weight").HasKey(u => u.Time);
			modelBuilder.Entity<MbmSleep>().ToTable("sleep").HasKey(u => u.Id);
			modelBuilder.Entity<MbmHeartrate>().ToTable("heartrate").HasKey(u => u.Time);
		}
	}
}