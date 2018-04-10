using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectOData.DAL
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class;
    }
}