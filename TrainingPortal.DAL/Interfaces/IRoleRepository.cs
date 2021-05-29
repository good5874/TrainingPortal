using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetRoles(int userId);
    }
}
