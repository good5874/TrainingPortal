using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("UserCourses")]
    public class UserCourses
    {
        public UserCourses()
        {

        }

        public UserCourses(int CourseId, int UserId, bool IsFinish)
        {
            this.CourseId = CourseId;
            this.UserId = UserId;
            this.IsFinish = IsFinish;
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsFinish { get; set; }
    }
}
