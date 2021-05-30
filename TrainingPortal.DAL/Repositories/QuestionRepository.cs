using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class QuestionRepository : AbstractRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(string conection) : base(conection) { }

        public void Create(Question item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Questions VALUES ('{item.QuestionText}', '{item.Answer}', '{item.TestId}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Questions WHERE (QuestionId = '{id}') ");
        }

        public Question Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Questions WHERE (QuestionId = '{id}')");
        }

        public IEnumerable<Question> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Questions");
        }

        public void Update(Question item)
        {
            ExecuteScalarSqlQuery($"UPDATE Questions SET Question = '{item.QuestionText}', Answer = '{item.Answer}', TestId = '{item.TestId}'" +
                 $" WHERE (QuestionId = '{item.QuestionId}')");
        }
    }
}
