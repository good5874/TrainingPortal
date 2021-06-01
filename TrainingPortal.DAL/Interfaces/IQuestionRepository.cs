using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public IEnumerable<Question> GetQuestions(int testId);
    }
}
