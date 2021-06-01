using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingPortal.Common.Models
{
    [Table("Tests")]
    public class Test
    {
        public Test()
        {

        }

        public Test(int TestId, string NameTest, int CourseId)
        {
            this.TestId = TestId;
            this.NameTest = NameTest;
            this.CourseId = CourseId;
        }

        [Required]
        public int TestId { get; set; }

        [Required]
        public string NameTest { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
