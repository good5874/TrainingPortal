using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Models
{
    public class ValidatedTestDTO
    {
        public string NameTest { get; set; }
        public string Result { get; set; }

        public List<(Question, string, bool)> ValidatedQuestions { get; set; }
    }
}
