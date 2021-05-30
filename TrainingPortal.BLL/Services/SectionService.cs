using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class SectionService : ISectionService
    {
        IUnitOfWork Database { get; set; }

        public SectionService(IUnitOfWork db)
        {
            Database = db;
        }

        public IEnumerable<Section> GetAll()
        {
            return Database.Sections.GetAll();
        }

        public Section Get(int id)
        {
            return Database.Sections.Get(id);
        }

        public void Create(Section item)
        {
            Database.Sections.Create(item);
        }

        public void Update(Section item)
        {
            Database.Sections.Update(item);
        }

        public void Delete(int id)
        {
            Database.Sections.Delete(id);
        }
    }
}
