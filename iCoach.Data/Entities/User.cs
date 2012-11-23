using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCoach.Data.Entities
{
    public class User: IdableEntity
    {
        [Required]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FacebookId { get; set; }
        public string VKId { get; set; }
        public string TwitterId { get; set; }

        public string Email { get; set; }

        public int PasswordFailuresSinceLastSuccess { get; set; }

        public DateTime? LastPasswordFailureDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public String ConfirmationToken { get; set; }
        public DateTime? CreateDate { get; set; }
        public Boolean IsLockedOut { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public String PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public virtual IList<UserRole> Roles { get; set; }
        public virtual IList<UserActivity> Activities { get; set; }
        public int CurrentScore { get; set; }
    }
}
