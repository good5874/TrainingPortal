using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRole(int roleId);
        void Create(Role role);
        void Update(Role role);
        void Delete(int id);
        IEnumerable<Role> GetRoles(int userId);
    }
}
