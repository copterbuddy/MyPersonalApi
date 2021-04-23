using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalApi.DAL.Interfaces
{
    public interface IBaseRepository
    {
        IEnumerable<T> Query<T>(string sql);
        IEnumerable<T> Query<T>(string sql, DynamicParameters parameter);
        IEnumerable<T> QueryStroedProcedure<T>(string spName, DynamicParameters parameter);
        int Execute<T>(string sql, DynamicParameters param);
        int Execute<T>(string sql);
    }
}
