using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public virtual IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Repository.GetAll(match);
        }
    }
}
