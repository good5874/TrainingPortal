using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IUserTestsService
    {
        IEnumerable<UserTests> GetAll();
        UserTests Get(int testId, int userId);
        void Create(UserTests item);
        void Delete(int testId, int userId);
        void Update(UserTests item);
        IEnumerable<UserTests> GetUserTests(int userId);
    }
}
