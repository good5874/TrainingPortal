using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class LessonRepository : AbstractCRUDRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(string conection) : base(conection) { }

        public IEnumerable<Lesson> GetLessons(int courseId)
        {
            return ExecuteSqlQuery($"SELECT * FROM Lessons WHERE (CourseId = '{courseId}')");
        }
    }
}
