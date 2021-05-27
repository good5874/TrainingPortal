using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
