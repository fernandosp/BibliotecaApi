using Dapper;
using Library.Infra.Repository.DbConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Library.Infra.Repository
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly IDbConnection dbConn;
        protected readonly IDbTransaction dbTransaction;

        public Repository(IDatabaseFactory databaseOptions)
        {
            dbConn = databaseOptions.GetDbConnection;
            dbConn.Open();
        }

        public Repository(IDbConnection databaseConnection, IDbTransaction transaction = null)
        {
            dbConn = databaseConnection;
            if (dbConn.State != ConnectionState.Open)
                dbConn.Open();
            dbTransaction = transaction;
        }

        public void Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Insert(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name} ({stringOfColumns}) values ({stringOfParameters})";

            using (var connection = dbConn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual void Delete(T entity)
        {
            var query = $"delete from {typeof(T).Name} where Id = @Id";

            using (var connection = dbConn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual void Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(T).Name} set {stringOfColumns} where Id = @Id";

            using (var connection = dbConn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual IEnumerable<T> Query(string where = null)
        {
            var query = $"select * from {typeof(T).Name} ";

            if (!string.IsNullOrWhiteSpace(where))
                query += $"where {where} ";

            using (var connection = dbConn)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return connection.Query<T>(query);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "ID" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}