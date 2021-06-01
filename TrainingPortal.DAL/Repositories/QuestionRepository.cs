using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class QuestionRepository : AbstractCRUDRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(string conection) : base(conection) { }

        public IEnumerable<Question> GetQuestions(int testId)
        {
            return ExecuteSqlQuery($"SELECT * FROM Questions WHERE (TestId = '{testId}')");
            throw new NotImplementedException();
        }
    }
}
