using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(Question question)
        {
            Database.Questions.Create(question);
        }

        public void Delete(int id)
        {
            Database.Questions.Delete(id);
        }

        public Question Get(int id)
        {
            return Database.Questions.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return Database.Questions.GetAll();
        }

        public void Update(Question question)
        {
            Database.Questions.Update(question);
        }
    }
}
