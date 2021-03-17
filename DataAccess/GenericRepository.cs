using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class GenericRepository : IGenericRepository
    {
        private string connectionStr;

        public GenericRepository(IConfiguration configuration)
        {
            this.connectionStr = configuration.GetConnectionString("dbName");
        }

        public List<T> GetAll<T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                var result = conn.Query<T>(sql).ToList();
                return result;
            }
        }

        public T Get<T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                var result = conn.Query<T>(sql).FirstOrDefault();
                return result;
            }
        }

        public int Create(string sql, object param)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                sql = $"{sql}; select SCOPE_IDENTITY()";
                int id = conn.Query<int>(sql, param).First();
                return id;
            }
        }

        public void Update(string sql, object param)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Execute(sql, param);
            }
        }

        public void Delete(string sql, object param)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Execute(sql, param);
            }
        }
    }
}
