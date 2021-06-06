using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Models
{
    public class TestViewModel
    {
        public int TestId { get; set; }
        public string NameCourse { get; set; }
        public string NameTest { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
