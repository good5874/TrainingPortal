using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User Get(int userId);
        User Get(string email);
        void Create(User user);
        void Update(User user);
        void Delete(int userId);
    }
}
