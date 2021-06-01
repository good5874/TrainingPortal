using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.BLL.Models;

namespace TrainingPortal.Models
{
    public class ResultTestViewModel
    {
        public ValidatedTestDTO Test { get; set; }
        public ValidatedCourseDTO Course { get; set; }
    }
}
