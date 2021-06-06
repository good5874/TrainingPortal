using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetAudience { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}
