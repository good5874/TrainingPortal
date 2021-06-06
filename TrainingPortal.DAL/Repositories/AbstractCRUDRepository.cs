using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TrainingPortal.DAL.Repositories
{
    public abstract class AbstractCRUDRepository<T> : AbstractRepository<T>
    {
        private TableAttribute tableAttribute { get; set; }

        public AbstractCRUDRepository(string conection) : base(conection)
        {
            tableAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute)) as TableAttribute;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return ExecuteSqlQuery($"SELECT * FROM {tableAttribute.Name}");
        }

        public virtual void Create(T item)
        {
            var properties = typeof(T).GetProperties().ToList();
            var resultProp = new List<string>();

            foreach (var prop in properties.Skip(1))
            {
                resultProp.Add($"'{item.GetType().GetProperty(prop?.Name).GetValue(item, null)}'");
            }

            var strValues = string.Join(", ", resultProp);

            ExecuteScalarSqlQuery($"INSERT INTO {tableAttribute.Name} VALUES ({strValues})");
        }

        public virtual void Delete(int id)
        {
            ExecuteScalarSqlQuery($"DELETE FROM {tableAttribute.Name} WHERE ({typeof(T).GetProperties()[0].Name} = '{id}') ");
        }

        public virtual T Get(int id)
        {
            return ExecuteScalarSqlQuery($"SELECT * FROM {tableAttribute.Name} WHERE ({typeof(T).GetProperties()[0].Name} = '{id}')");
        }

        public virtual void Update(T item)
        {
            var properties = typeof(T).GetProperties().ToList();
            var resultProp = new List<string>();

            foreach (var prop in properties.Skip(1))
            {
                resultProp.Add($"{prop.Name} = '{item.GetType().GetProperty(prop?.Name).GetValue(item, null)}'");
            }

            var strValues = string.Join(", ", resultProp);

            ExecuteScalarSqlQuery($"UPDATE {tableAttribute.Name} SET {strValues}" +
                $" WHERE ({properties[0].Name} = '{item.GetType().GetProperty(properties?[0].Name).GetValue(item, null)}')");
        }

    }
}
