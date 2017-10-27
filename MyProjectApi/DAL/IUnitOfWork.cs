using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public interface IUnitOfWork
    {
        //Repository<T> Repository<T>() where T : class;
        T Get<T>(Expression<Func<T, bool>> match) where T : class;
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class;
        T Add<T>(T model) where T : class;
        T Update<T>(T updated, params object[] keyValues) where T : class;
        void Delete<T>(T model) where T : class;
        void Save();
    }
}