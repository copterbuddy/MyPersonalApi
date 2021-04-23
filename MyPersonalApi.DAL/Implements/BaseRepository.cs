using Dapper;
using MyPersonalApi.DAL.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace MyPersonalApi.DAL.Implements
{
    public class BaseRepository : IBaseRepository
    {

        private readonly string ConnectionString;
        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private T WithConnection<T>(Func<IDbConnection, T> getData)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    return getData(connection);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return WithConnection(c => c.Query<T>(sql));
        }
        public IEnumerable<T> Query<T>(string sql, DynamicParameters parameter)
        {
            return WithConnection(c => c.Query<T>(sql, parameter));
        }

        public IEnumerable<T> QueryStroedProcedure<T>(string spName, DynamicParameters parameter)
        {
            return WithConnection(c => c.Query<T>(spName, parameter, commandType: CommandType.StoredProcedure));
        }

        public int Execute<T>(string sql, DynamicParameters param)
        {
            return WithConnection(c => c.Execute(sql, param));
        }

        public int Execute<T>(string sql)
        {
            return WithConnection(c => c.Execute(sql));
        }
    }
}
