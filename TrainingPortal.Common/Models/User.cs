using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {

        }

        public User(int UserId, string UserName, string FullName, string Email, string Password)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.FullName = FullName;
            this.Email = Email;
            this.Password = Password;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
