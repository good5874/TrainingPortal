using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UserCoursesRepository : AbstractRepository<UserCourses>, IUserCoursesRepository
    {
        public UserCoursesRepository(string conection) : base(conection) { }

        public void Create(UserCourses item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO UserCourses VALUES ('{item.CourseId}', '{item.UserId}', '{item.IsFinish}')");
        }

        public void Delete(int courseId, int userId)
        {
            ExecuteScalarSqlQuery($"DELETE FROM UserCourses WHERE ((CourseId = '{courseId}') AND (UserId = '{userId}')) ");
        }

        public UserCourses Get(int courseId, int userId)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM UserCourses WHERE ((CourseId = '{courseId}') AND (UserId = '{userId}'))");
        }

        public IEnumerable<UserCourses> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM UserCourses");
        }

        public void Update(UserCourses item)
        {
            ExecuteScalarSqlQuery($"UPDATE UserCourses SET IsFinish = '{item.IsFinish}' WHERE ((CourseId = '{item.CourseId}') AND (UserId = '{item.UserId}'))");
        }
    }
}
