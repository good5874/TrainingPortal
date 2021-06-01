using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TrainingPortal.BLL.Models;
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
        IEnumerable<Course> GetCourse(int sectionId);
        IEnumerable<Course> GetFinishedCourses(int userId);
        public ValidatedCourseDTO CheckCourse(int courseId, ClaimsPrincipal userClaim);
    }
}
