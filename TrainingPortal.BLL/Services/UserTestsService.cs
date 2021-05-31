using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class UserTestsService : IUserTestsService
    {
        IUnitOfWork Database { get; set; }

        public UserTestsService(IUnitOfWork db)
        {
            Database = db;
        }

        public IEnumerable<UserTests> GetAll()
        {
            return Database.UserTests.GetAll();
        }

        public UserTests Get(int testId, int userId)
        {
            return Database.UserTests.Get(testId, userId);
        }

        public void Create(UserTests item)
        {
            Database.UserTests.Create(item);
        }

        public void Delete(int testId, int userId)
        {
            Database.UserTests.Delete(testId, userId);
        }

        public void Update(UserTests item)
        {
            Database.UserTests.Update(item);
        }
    }
}
