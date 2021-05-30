using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class CourseRepository : AbstractRepository<Course>, IСourseRepository
    {
        public CourseRepository(string conection) : base(conection) { }

        public void Create(Course item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Сourses VALUES ('{item.Name}', '{item.Description}', '{item.TargetAudience}', '{item.SectionId}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Сourses WHERE (CourseId = '{id}') ");
        }

        public Course Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Сourses WHERE (CourseId = '{id}')");
        }

        public IEnumerable<Course> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Сourses");
        }

        public void Update(Course item)
        {
            ExecuteScalarSqlQuery($"UPDATE Сourses SET Name = '{item.Name}', Description = '{item.Description}'," +
                $" TargetAudience = '{item.TargetAudience}', SectionId = '{item.SectionId}'" +
                $" WHERE (CourseId = '{item.CourseId}')");
        }
    }
}
