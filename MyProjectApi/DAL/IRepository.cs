using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public interface IRepository
    {
        T Get<T>(Expression<Func<T, bool>> match) where T : class;
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class;
        T Update<T>(T updated) where T : class;
        void Delete<T>(Expression<Func<T, bool>> condition) where T : class;
        T Add<T>(T model) where T : class;
        void Save();
    }
}