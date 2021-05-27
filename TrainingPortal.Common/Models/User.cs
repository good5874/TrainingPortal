using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int UserId, string UserName, string Email, string Password)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
        }
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
