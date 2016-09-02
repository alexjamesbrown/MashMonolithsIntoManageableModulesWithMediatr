using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CashJobSite.Data.Repositories
{
    public interface IRepository<T> 
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Save(T entity);
        void Delete(T entity);
    }
}
