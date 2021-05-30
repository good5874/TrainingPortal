using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course Get(int id);
        void Create(Course item);
        void Update(Course item);
        void Delete(int id);
    }
}
