using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectBusinessLayer.Generic
{
    public interface IRetriever<TModel, TViewModel> : IRetriever<TModel>
    {
        new TViewModel Get(Expression<Func<TModel, bool>> match);
        new IEnumerable<TViewModel> GetAll(Expression<Func<TModel, bool>> match);
        TModel GetModel(Expression<Func<TModel, bool>> match);
        IEnumerable<TModel> GetAllModels(Expression<Func<TModel, bool>> match);
    }

    public interface IRetriever<TModel>
    {
        TModel Get(Expression<Func<TModel, bool>> match);
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> match);
    }
}