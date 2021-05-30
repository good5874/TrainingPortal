using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class CertificateRepository : AbstractRepository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(string conection) : base(conection) { }

        public void Create(Certificate item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Certificates VALUES ('{item.CourseId}','{item.UserId}','{item.NameCourse}', '{item.FullName}')");
        }

        public void Delete(int courseId, int userId)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Certificates WHERE ((CourseId = '{courseId}') AND (UserId = '{userId}'))");
        }

        public Certificate Get(int courseId, int userId)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Certificates WHERE ((CourseId = '{courseId}') AND (UserId = '{userId}'))");
        }

        public IEnumerable<Certificate> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Certificates");
        }

        public void Update(Certificate item)
        {
            ExecuteScalarSqlQuery($"UPDATE Certificates SET NameCourse = '{item.NameCourse}', FullName = '{item.FullName}'" +
                 $" WHERE ((CourseId = '{item.CourseId}') AND (UserId = '{item.UserId}'))");
        }
    }
}
