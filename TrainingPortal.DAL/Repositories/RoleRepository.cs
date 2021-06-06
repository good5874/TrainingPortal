using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class RoleRepository : AbstractCRUDRepository<Role>, IRoleRepository
    {
        public RoleRepository(string conection) : base(conection) { }

        public IEnumerable<Role> GetRoles(int userId)
        {
            return ExecuteSqlQuery($"SELECT Roles.RoleId, Roles.Name FROM Roles, UserRoles" +
                $" WHERE ((Roles.RoleId = UserRoles.RoleId) AND (UserRoles.UserId = {userId}))");
        }
    }
}
