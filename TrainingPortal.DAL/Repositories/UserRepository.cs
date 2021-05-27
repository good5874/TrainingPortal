using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(string conection) : base(conection) { }

        public IEnumerable<User> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Users");
        }

        public User Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Users WHERE (UserId = '{id}')");
        }

        public void Create(User item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Users VALUES ('{item.UserName}', '{item.Email}', '{item.Password}')");
        }

        public void Update(User item)
        {
            ExecuteScalarSqlQuery($"UPDATE Users SET UserName = '{item.UserName}', Email = '{item.Email}'," +
                $" Password = '{item.Password}'" +
                $" WHERE (UserId = '{item.UserId}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Users WHERE (UserId = '{id}') ");
        }

        public User Get(string email)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Users WHERE (Email = '{email}')");
        }
    }
}
