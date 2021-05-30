using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class UserCourses
    {
        public UserCourses()
        {

        }

        public UserCourses(int CourseId, int UserId)
        {
            this.CourseId = CourseId;
            this.UserId = UserId;
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsFinish { get; set; }
    }
}
