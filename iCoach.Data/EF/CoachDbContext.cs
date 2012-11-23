using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCoach.Data.Entities;
using iCoach.Data.Migrations;

namespace iCoach.Data.EF
{
    public interface ICoachDb
    {
        IQueryable<User> Users { get; }
        IQueryable<UserRole> UserRoles { get; }
        IQueryable<UserActivity> UserActivities { get; }

        void SaveChanges();
    }

    public class CoachDbContext: DbContext, ICoachDb
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        
        public void SaveChanges()
        {
            this.SaveChanges();
        }

        IQueryable<User> ICoachDb.Users
        {
            get { return this.Users; }
        }

        IQueryable<UserRole> ICoachDb.UserRoles
        {
            get { return this.UserRoles; }
        }

        IQueryable<UserActivity> ICoachDb.UserActivities
        {
            get { return this.UserActivities; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tell Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //set the initializer to migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoachDbContext, Configuration>());
        }
    }
}
