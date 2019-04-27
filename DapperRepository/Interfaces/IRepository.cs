using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Func<T,bool> predicate);
        long Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
