using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectOData.DAL
{
    public interface IRepository
    {
        T Get<T>(Expression<Func<T, bool>> match) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class;
    }
}