using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ICourseRepository: IRepository<Course>
    {
        public IEnumerable<Course> GetFinishedCourses(int userId);
        public IEnumerable<Course> GetCourse(int sectionId);
    }
}
