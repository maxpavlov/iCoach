using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iCoach.Data.Entities
{
    public class UserRole : IdableEntity
    {
        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool AdminFeaturesAvailable { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
