using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectOData.Retrievers
{
    public interface IRetriever<TModel>
    {
        TModel Get(Expression<Func<TModel, bool>> match);
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> match);
    }
}