using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IUserRolesRepository
    {
        IEnumerable<UserRole> GetAll();
        void Create(int userId, int roleId);
        void Delete(int userId, int roleId);
    }
}
