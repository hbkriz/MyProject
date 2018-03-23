using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectDataLayer.DAL
{
    public class Repository : IRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public T Get<T>(Expression<Func<T, bool>> match) where T : class
        {
            return _unitOfWork.Set<T>().SingleOrDefault(match);
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return _unitOfWork.Set<T>().Find(keyValues);
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class
        {
            return condition != null ? _unitOfWork.Set<T>().Where(condition) : _unitOfWork.Set<T>();
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public T Update<T>(T updated) where T : class
        {
            _unitOfWork.DbEntityEntry(updated).State = EntityState.Modified;
            return updated;
        }

        public void Delete<T>(T t) where T : class
        {
            _unitOfWork.Set<T>().Remove(t);
        }

        public T Add<T>(T model) where T : class
        {
            return _unitOfWork.Set<T>().Add(model);
        }
    }
}