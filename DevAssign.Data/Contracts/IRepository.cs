using System;
using System.Linq;
using System.Linq.Expressions;

namespace DevAssign.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(string include = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, string include = null);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
