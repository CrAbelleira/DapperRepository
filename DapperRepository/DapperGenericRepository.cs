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
        private IDbTransaction transaction;

        public void Delete(T entity)
        {
            if(this.transaction== null)
            {
                this.transaction = connection.BeginTransaction();
            }
            connection.Delete<T>(entity);
        }

        public T Get(long id)
        {
            if (this.transaction == null)
            {
                this.transaction = connection.BeginTransaction();
            }
            return connection.Get<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            if (this.transaction == null)
            {
                this.transaction = connection.BeginTransaction();
            }
            return connection.GetAll<T>().AsQueryable<T>();
        }

        public IQueryable<T> GetBy(Func<T, bool> predicate)
        {
            if (this.transaction == null)
            {
                this.transaction = connection.BeginTransaction();
            }
            return connection.GetAll<T>().AsQueryable<T>().Where<T>(predicate).AsQueryable();
        }

        public long Insert(T entity)
        {
            if (this.transaction == null)
            {
                this.transaction = connection.BeginTransaction();
            }
            return connection.Insert<T>(entity);
        }

        public void Update(T entity)
        {
            if (this.transaction == null)
            {
                this.transaction = connection.BeginTransaction();
            }
            connection.Update<T>(entity);
        }

        public DapperGenericRepository(DapperContext context)
        {
            this.connection = context.connection;
            this.transaction = context.transaction;           
        }


    }
}

  