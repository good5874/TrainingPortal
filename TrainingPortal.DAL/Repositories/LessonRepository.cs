using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class LessonRepository : AbstractRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(string conection) : base(conection) { }

        public void Create(Lesson item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Lessons VALUES ('{item.NameLesson}', '{item.Material}', '{item.CourseId}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Lessons WHERE (LessonId = '{id}') ");
        }

        public Lesson Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Lessons WHERE (LessonId = '{id}')");
        }

        public IEnumerable<Lesson> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Lessons");
        }

        public void Update(Lesson item)
        {
            ExecuteScalarSqlQuery($"UPDATE Lessons SET NameLesson = '{item.NameLesson}', Material = '{item.Material}'" +
                $" WHERE (LessonId = '{item.LessonId}')");
        }
    }
}
