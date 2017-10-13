using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public interface IService<T> where T : class
    {
        T Get(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null);
        void Update(T model);
        void Delete(T model);
        T Create(T model);
    }
}