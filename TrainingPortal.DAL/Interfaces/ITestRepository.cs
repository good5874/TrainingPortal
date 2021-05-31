using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        public IEnumerable<Test> GetTests(int courseId);
    }
}
