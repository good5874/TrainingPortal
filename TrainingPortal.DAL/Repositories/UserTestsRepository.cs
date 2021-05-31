using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UserTestsRepository : AbstractRepository<UserTests>, IUserTestsRepository
    {
        public UserTestsRepository(string conection) : base(conection) { }

        public void Create(UserTests item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO UserTests VALUES ('{item.TestId}', '{item.UserId}', '{item.IsFinish}')");
        }

        public void Delete(int testId, int userId)
        {
            ExecuteScalarSqlQuery($"DELETE FROM UserTests WHERE ((TestId = '{testId}') AND (UserId = '{userId}')) ");
        }

        public UserTests Get(int testId, int userId)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM UserTests WHERE ((TestId = '{testId}') AND (UserId = '{userId}'))");
        }

        public IEnumerable<UserTests> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM UserTests");
        }

        public void Update(UserTests item)
        {
            ExecuteScalarSqlQuery($"UPDATE UserTests SET IsFinish = '{item.IsFinish}' WHERE ((TestId = '{item.TestId}') AND (UserId = '{item.UserId}'))");
        }
    }
}
