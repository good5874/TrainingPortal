using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class Lesson
    {
        public Lesson()
        {

        }

        public Lesson(int LessonId, string NameLesson, string Material, int CourseId)
        {
            this.LessonId = LessonId;
            this.NameLesson = NameLesson;
            this.Material = Material;
            this.CourseId = CourseId;
        }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public string NameLesson { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
