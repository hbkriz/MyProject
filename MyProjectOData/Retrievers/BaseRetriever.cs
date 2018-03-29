using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyProjectOData.DAL;

namespace MyProjectOData.Retrievers
{
    public abstract class BaseRetriever<TModel> : IRetriever<TModel>
        where TModel : class
    {
        protected IRepository Repository { get; set; }
        protected BaseRetriever(IRepository repository)
        {
            Repository = repository;
        }

        public virtual TModel Get(Expression<Func<TModel, bool>> match)
        {
            return Repository.Get(match);
        }

        public virtual IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Repository.GetAll(match);
        }
    }
}
