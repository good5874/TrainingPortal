using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class SectionRepository : AbstractRepository<Section>, ISectionRepository
    {
        public SectionRepository(string conection) : base(conection) { }

        public void Create(Section item)
        {
            ExecuteScalarSqlQuery($"INSERT INTO Sections VALUES ('{item.Name}')");
        }

        public void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM Sections WHERE (SectionId = '{id}')");
        }

        public Section Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM Sections WHERE (SectionId = '{id}')");
        }

        public IEnumerable<Section> GetAll()
        {
            return ExecuteSqlQuery("SELECT * FROM Sections");
        }

        public void Update(Section item)
        {
           ExecuteScalarSqlQuery($"UPDATE Sections SET Name = '{item.Name}' WHERE (SectionId = '{item.SectionId}')");
        }
    }
}
