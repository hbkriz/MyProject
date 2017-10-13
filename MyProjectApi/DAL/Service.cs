using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public class Service<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<T> Repository => _unitOfWork.Repository<T>();

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
           return Repository.Get(condition);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null)
        {
            return condition == null ? Repository.GetAll() : Repository.GetAll(condition);
        }

        public void Update(T model)
        {
            Repository.Update(model);
        }

        public void Delete(T model)
        {
            Repository.Delete(model);
        }

        public T Create(T model)
        {
            return Repository.Add(model);
        }

    }
}