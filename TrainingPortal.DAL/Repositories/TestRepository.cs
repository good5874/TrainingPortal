using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class TestRepository : AbstractRepository<Test>, ITestRepository
    {
        public TestRepository(string conection) : base(conection) { }

        public void Create(Test item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Tests VALUES ('{item.NameTest}', '{item.CourseId}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Tests WHERE (TestId = '{id}') ");
        }

        public Test Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Tests WHERE (TestId = '{id}')");
        }

        public IEnumerable<Test> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Tests");
        }

        public void Update(Test item)
        {
            ExecuteScalarSqlQuery($"UPDATE Lessons SET NameTest = '{item.NameTest}', CourseId = '{item.CourseId}' WHERE (TestId = '{item.TestId}')");
        }
    }
}
