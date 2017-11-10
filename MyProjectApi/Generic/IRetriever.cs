using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.Generic
{
    public interface IRetriever<TModel, TViewModel> : IRetriever<TModel>
    {
        new TViewModel Get(Expression<Func<TModel, bool>> match);
        new IList<TViewModel> GetAll(Expression<Func<TModel, bool>> match);
    }

    public interface IRetriever<TModel>
    {
        TModel Get(Expression<Func<TModel, bool>> match);
        IList<TModel> GetAll(Expression<Func<TModel, bool>> match);
    }
}