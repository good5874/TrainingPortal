using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class Course
    {
        public Course()
        {

        }

        public Course(int CourseId, string Name, string Description, string NameSection, string TargetAudience)
        {
            this.CourseId = CourseId;
            this.Name = Name;
            this.Description = Description;
            this.NameSection = NameSection;
            this.TargetAudience = TargetAudience;
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string NameSection { get; set; }

        [Required]
        public string TargetAudience { get; set; }
    }
}
