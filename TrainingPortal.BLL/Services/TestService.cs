using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(Test test)
        {
            Database.Tests.Create(test);
        }

        public void Delete(int id)
        {
            Database.Tests.Delete(id);
        }

        public Test Get(int id)
        {
            return Database.Tests.Get(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return Database.Tests.GetAll();
        }

        public void Update(Test test)
        {
            Database.Tests.Update(test);
        }
    }
}
