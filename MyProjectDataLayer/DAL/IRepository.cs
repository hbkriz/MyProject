using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectDataLayer.DAL
{
    public interface IRepository
    {
        T Get<T>(Expression<Func<T, bool>> match) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class;
        T Update<T>(T updated) where T : class;
        void Delete<T>(T t) where T : class;
        T Add<T>(T model) where T : class;
        void Save();
    }
}