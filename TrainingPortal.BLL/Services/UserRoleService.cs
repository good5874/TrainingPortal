using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class UserRoleService : IUserRolesService
    {
        IUnitOfWork Database { get; set; }

        public UserRoleService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(int userId, int roleId)
        {
            Database.UserRoles.Create(userId, roleId);
        }

        public void Delete(int userId, int roleId)
        {
            Database.UserRoles.Delete(userId, roleId);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return Database.UserRoles.GetAll();
        }
    }
}
