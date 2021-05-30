using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class LessonService : ILessonService
    {
        IUnitOfWork Database { get; set; }

        public LessonService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(Lesson item)
        {
            Database.Lessons.Create(item);
        }

        public void Delete(int id)
        {
            Database.Lessons.Delete(id);
        }

        public Lesson Get(int id)
        {
            return Database.Lessons.Get(id);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return Database.Lessons.GetAll();
        }

        public void Update(Lesson item)
        {
            Database.Lessons.Update(item);
        }
    }
}
