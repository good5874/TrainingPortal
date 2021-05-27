using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
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
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
