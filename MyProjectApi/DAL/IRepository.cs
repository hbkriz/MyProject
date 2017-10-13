using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> match);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> match);
        T Add(T t);
        T Update(T t);
        void Delete(T t);
    }
}