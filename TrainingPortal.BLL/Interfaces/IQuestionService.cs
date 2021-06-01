using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        Question Get(int id);
        void Create(Question question);
        void Update(Question question);
        void Delete(int id);
        public IEnumerable<Question> GetQuestions(int testId);
    }
}
