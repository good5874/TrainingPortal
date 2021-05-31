using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class UserTests
    {
        public UserTests()
        {

        }

        public UserTests(int TestId, int UserId)
        {
            this.TestId = TestId;
            this.UserId = UserId;
        }

        [Required]
        public int TestId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsFinish { get; set; }
    }
}
