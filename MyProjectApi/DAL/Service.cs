using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public class Service<T> : IService<T> where T : class
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

        public T Update(T model)
        {
            var updatedModel = Repository.Update(model);
            _unitOfWork.Save();
            return updatedModel;
        }

        public void Delete(T model)
        {
            Repository.Delete(model);
            _unitOfWork.Save();
        }

        public T Create(T model)
        {
            var addedModel = Repository.Add(model);
            _unitOfWork.Save();
            return addedModel;
        }
    }
}