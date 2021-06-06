using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("Certificates")]
    public class Certificate
    {
        public Certificate()
        {

        }

        public Certificate(int CourseId, int UserId, string FullName, string NameCourse)
        {
            this.CourseId = CourseId;
            this.UserId = UserId;
            this.FullName = FullName;
            this.NameCourse = NameCourse;
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string NameCourse { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
