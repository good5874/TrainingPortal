using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ITestService
    {
        IEnumerable<Test> GetAll();
        Test Get(int id);
        void Create(Test test);
        void Update(Test test);
        void Delete(int id);
    }
}
