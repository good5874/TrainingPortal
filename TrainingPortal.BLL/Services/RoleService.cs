using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(Role role)
        {
            Database.Roles.Create(role);
        }

        public void Delete(int roleId)
        {
           Database.Roles.Delete(roleId);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Database.Roles.GetAll();
        }

        public Role GetRole(int roleId)
        {
            return Database.Roles.Get(roleId);
        }

        public IEnumerable<Role> GetRoles(int userId)
        {
            return Database.Roles.GetRoles(userId);
        }

        public void Update(Role role)
        {
            Database.Roles.Update(role);
        }
    }
}
