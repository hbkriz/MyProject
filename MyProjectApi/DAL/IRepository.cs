using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null);
        //T Update(T updated, params object[] keyValues);
        //void Delete(Expression<Func<T, bool>> condition);
        //T Add(T model);
    }
}