using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IUserRolesService
    {
        IEnumerable<UserRole> GetAll();
        void Create(int userId, int roleId);
        void Delete(int userId, int roleId);
    }
}
