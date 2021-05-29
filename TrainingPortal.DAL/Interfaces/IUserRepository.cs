using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string email);
    }
}
