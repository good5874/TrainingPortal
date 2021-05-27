using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TrainingPortal.DAL.Repositories
{
    public abstract class AbstractRepository<T> : IDisposable
    {
        private SqlConnection Connection { get; set; }
        public AbstractRepository(string conection)
        {
            Connection = new SqlConnection(conection);
        }
        public IEnumerable<T> ExecuteSqlQuery(string sqlQuery)
        {
            List<T> items = new List<T>();
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(sqlQuery, Connection);
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row.ItemArray);
                items.Add(item);
            }
            return items;
        }

        public T ExecuteScalarSqlQuery(string sqlQuery)
        {
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(sqlQuery, Connection);
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                T item = (T)Activator.CreateInstance(typeof(T), table.Rows[0].ItemArray);
                return item;
            }
            else
            {
                return default(T);
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
