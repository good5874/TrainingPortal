using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.DAL.Repositories
{
    public class SectionRepository : AbstractCRUDRepository<Section>, ISectionRepository
    {
        public SectionRepository(string conection) : base(conection) { }
    }
}
