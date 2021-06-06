using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        public UserRole()
        {

        }

        public UserRole(int UserId, int RoleId)
        {
            this.UserId = UserId;
            this.RoleId = RoleId;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
