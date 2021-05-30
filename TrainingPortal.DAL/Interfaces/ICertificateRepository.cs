using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.DAL.Interfaces
{
    public interface ICertificateRepository
    {
        IEnumerable<Certificate> GetAll();
        Certificate Get(int courseId, int userId);
        void Create(Certificate item);
        void Update(Certificate item);
        void Delete(int courseId, int userId);
    }
}
