using Dapper;
using Dapper.Contrib.Extensions;
using DapperRepository.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace DapperRepository
{
    public class DapperGenericRepository<T> : IRepository<T> where T : class
    {

        private IDbConnection connection;

        public void Delete(T entity)
        {
            connection.Delete<T>(entity);
        }

        public T Get(long id)
        {
            return connection.Get<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return connection.GetAll<T>().AsQueryable<T>();
        }

        public IQueryable<T> GetBy(Func<T, bool> predicate)
        {
            return connection.GetAll<T>().AsQueryable<T>().Where<T>(predicate).AsQueryable();
        }

        public long Insert(T entity)
        {
           return connection.Insert<T>(entity);
        }

        public void Update(T entity)
        {
            connection.Update<T>(entity);
        }

        public DapperGenericRepository(IDbConnection connection)
        {
            this.connection = connection;
        }


    }
}
