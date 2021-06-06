using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TrainingPortal.BLL.Models;
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
        public IEnumerable<Test> GetTests(int courseId);
        public ValidatedTestDTO CheckTest(int testId, List<string> results, ClaimsPrincipal userClaim);

    }
}
