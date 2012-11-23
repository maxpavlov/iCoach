using System.Collections.Generic;
using System.Data.SqlTypes;
using iCoach.Data.Entities;
using iCoach.Data.Utils;

namespace iCoach.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iCoach.Data.EF.CoachDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(iCoach.Data.EF.CoachDbContext context)
        {
            var roles = new List<UserRole>
                {
                    new UserRole()
                        {
                            Id = Guid.Parse("9727d3e4-0269-46e1-ad7c-bfbdc9c074bc"),
                            RoleName = "Admin"
                        },
                    new UserRole()
                        {
                            Id = Guid.Parse("b22380eb-1c28-4945-b12d-38c55099036a"),
                            RoleName = "ProjectsManager"
                        }
                };

            foreach (var webUserRole in roles.Where(webUserRole => !context.UserRoles.Any(rl => rl.RoleName == webUserRole.RoleName)))
            {
                context.UserRoles.Add(webUserRole);
            }

            var mp = new User()
            {
                Id = Guid.Parse("479460f6-06c1-43fb-96c3-6ff161255c04"),
                CreateDate = DateTime.Now,
                UserName = "MaxPavlov",
                Password = Crypto.HashPassword("jackPecker"),
                Roles = context.UserRoles.Local.Where(rl => rl.RoleName == "Admin").ToList(),
                IsLockedOut = false,
                LastActivityDate = SqlDateTime.MinValue.Value,
                LastLoginDate = SqlDateTime.MinValue.Value,
                LastLockoutDate = SqlDateTime.MinValue.Value,
                LastPasswordChangedDate = SqlDateTime.MinValue.Value,
                LastPasswordFailureDate = SqlDateTime.MinValue.Value,
                PasswordVerificationTokenExpirationDate = SqlDateTime.MinValue.Value
            };

            if (!context.Users.Any(usr => usr.UserName == mp.UserName)) context.Users.Add(mp);

            base.Seed(context);
        }
    }
}
