using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class RoleRepository : AbstractRepository<Role>, IRoleRepository
    {
        public RoleRepository(string conection) : base(conection) { }

        public void Create(Role item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Roles VALUES ('{item.Name}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Roles WHERE (RoleId = '{id}') ");
        }

        public Role Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Roles WHERE (RoleId = '{id}')");
        }

        public IEnumerable<Role> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Roles");
        }

        public IEnumerable<Role> GetRoles(int userId)
        {
            return ExecuteSqlQuery($"SELECT Roles.RoleId, Roles.Name FROM Roles, UserRoles" +
                $" WHERE ((Roles.RoleId = UserRoles.RoleId) AND (UserRoles.UserId = {userId}))");
        }

        public void Update(Role item)
        {
            ExecuteScalarSqlQuery($"UPDATE Roles SET Name = '{item.Name}' WHERE (RoleId = '{item.RoleId}')");
        }
    }
}
