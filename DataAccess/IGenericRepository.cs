using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IGenericRepository
    {
        List<T> GetAll<T>(string sql);

        T Get<T>(string sql);

        int Create(string sql, object param);

        void Update(string sql, object param);

        void Delete(string sql, object param);
    }
}
