using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UserRepository : AbstractCRUDRepository<User>, IUserRepository
    {
        public UserRepository(string conection) : base(conection) { }

        public User Get(string email)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Users WHERE (Email = '{email}')");
        }
    }
}
