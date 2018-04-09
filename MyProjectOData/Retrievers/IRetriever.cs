using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectOData.Retrievers
{
    public interface IRetriever<TModel>
    {
        IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> match);
    }
}