using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        IEnumerable<Lesson> GetLessons(int courseId);
    }
}
