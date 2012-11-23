using System;
using System.ComponentModel.DataAnnotations;

namespace iCoach.Data.Entities
{
    public abstract class ActionStampable
    {
        [Required]
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string CreatorID { get; set; }
        [Required]
        public string CreatorIP { get; set; }
    }
}
