using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IUserCoursesService
    {
        IEnumerable<UserCourses> GetAll();
        UserCourses Get(int courseId, int userId);
        void Create(UserCourses item);
        void Delete(int courseId, int userId);
        void Update(UserCourses item);
    }
}
