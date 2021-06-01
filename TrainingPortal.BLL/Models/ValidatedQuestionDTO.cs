using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Models
{
    public class ValidatedQuestionDTO
    {
        public Question Question { get; set; }
        public string Answer { get; set; }
        public bool Result { get; set; }
    }
}
