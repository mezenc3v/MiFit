using System;
using System.Linq;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore.Tests
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            Initialize(context.Activities);
            Initialize(context.Bodies);
            Initialize(context.Users);
            Initialize(context.Sleeps);
            Initialize(context.Heartrates);
        }

        private static void Initialize(DbSet<Activity> activities)
        {
            if (activities.Any())
                return;
            //add
        }
        private static void Initialize(DbSet<Body> bodies)
        {
            if (bodies.Any())
                return;
            //add
        }
        private static void Initialize(DbSet<User> users)
        {
            if (users.Any())
                return;
            //add
        }
        private static void Initialize(DbSet<Sleep> sleeps)
        {
            if (sleeps.Any())
                return;
            //add
        }
        private static void Initialize(DbSet<Heartrate> heartrates)
        {

            if (heartrates.Any())
                return;
            //add
        }
    }
}
