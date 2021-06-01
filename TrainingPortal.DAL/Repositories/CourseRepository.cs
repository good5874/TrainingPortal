using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class CourseRepository : AbstractCRUDRepository<Course>, ICourseRepository
    {
        public CourseRepository(string conection) : base(conection) { }

        public IEnumerable<Course> GetCourse(int sectionId)
        {
            return ExecuteSqlQuery($"SELECT * FROM Сourses  WHERE (SectionId = '{sectionId}')");
        }

        public IEnumerable<Course> GetFinishedCourses(int userId)
        {
            return ExecuteSqlQuery($"SELECT Сourses.CourseId, Сourses.Name, Сourses.Description, Сourses.TargetAudience, Сourses.SectionId" +
                $" FROM Сourses, UserCourses  WHERE ((UserCourses.CourseId = Сourses.CourseId) AND (UserCourses.UserId = {userId})" +
                $" AND (UserCourses.IsFinish = '1'))");
        }
    }
}
