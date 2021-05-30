using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ILessonService
    {
        IEnumerable<Lesson> GetAll();
        Lesson Get(int id);
        void Create(Lesson item);
        void Update(Lesson item);
        void Delete(int id);
    }
}
