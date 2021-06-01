using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class TestRepository : AbstractCRUDRepository<Test>, ITestRepository
    {
        public TestRepository(string conection) : base(conection) { }

        public IEnumerable<Test> GetTests(int courseId)
        {
            return ExecuteSqlQuery($"SELECT * FROM Tests WHERE (CourseId = '{courseId}')");
        }
    }
}
