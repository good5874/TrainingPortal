using System;
using System.Collections.Generic;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ISectionService
    {
        IEnumerable<Section> GetAll();
        Section Get(int id);
        void Create(Section item);
        void Update(Section item);
        void Delete(int id);
    }
}
