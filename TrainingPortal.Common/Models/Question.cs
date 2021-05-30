using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class Question
    {
        public Question()
        {

        }

        public Question(int QuestionId, string QuestionText, string Answer, int TestId)
        {
            this.QuestionId = QuestionId;
            this.QuestionText = QuestionText;
            this.Answer = Answer;
            this.TestId = TestId;
        }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public int TestId { get; set; }
    }
}
