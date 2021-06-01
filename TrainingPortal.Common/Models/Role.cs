using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("Roles")]
    public class Role
    {
        public Role()
        {

        }

        public Role(int RoleId, string Name)
        {
            this.RoleId = RoleId;
            this.Name = Name;
        }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
