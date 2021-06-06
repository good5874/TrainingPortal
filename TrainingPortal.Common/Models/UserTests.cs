using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("UserTests")]
    public class UserTests
    {
        public UserTests()
        {

        }

        public UserTests(int TestId, int UserId, bool IsFinish)
        {
            this.TestId = TestId;
            this.UserId = UserId;
            this.IsFinish = IsFinish;
        }

        [Required]
        public int TestId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsFinish { get; set; }
    }
}
