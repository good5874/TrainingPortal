using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRolesRepository UserRoles { get; }
        IRoleRepository Roles { get; }
        ISectionRepository Sections { get; }
        ICourseRepository Courses { get; }
        IUserCoursesRepository UserCourses { get; }
        ICertificateRepository Certificates { get; }
        ILessonRepository Lessons { get; }
        ITestRepository Tests { get; }
        IQuestionRepository Questions { get; }
    }
}
