using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class UserRolesRepository : AbstractRepository<UserRole>, IUserRolesRepository
    {

        public UserRolesRepository(string conection) : base(conection) { }

        public void Create(int userId, int roleId)
        {
            ExecuteScalarSqlQuery($"INSERT INTO UserRoles VALUES ('{userId}', '{roleId}')");
        }

        public void Delete(int userId, int roleId)
        {
            ExecuteScalarSqlQuery($"DELETE FROM UserRoles WHERE ((UserId = '{userId}') AND (RoleId = '{roleId}')) ");
        }

        public IEnumerable<UserRole> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM UserRoles");
        }
    }
}
