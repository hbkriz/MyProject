using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
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

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class
        {
            return condition != null ? _unitOfWork.Set<T>().Where(condition) : _unitOfWork.Set<T>();
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public T Update<T>(T updated) where T : class
        {
            if (updated == null) return null;
            _unitOfWork.DbEntityEntry(updated).State = EntityState.Modified;
            return updated;
        }

        public void Delete<T>(Expression<Func<T, bool>> condition) where T : class
        {
            var model = _unitOfWork.Set<T>().SingleOrDefault(condition);
            if (model == null) throw new NullReferenceException(typeof(T) + " model not found");
            if (_unitOfWork.DbEntityEntry(model).State == EntityState.Detached)
            {
                _unitOfWork.Set<T>().Attach(model);
            }
            _unitOfWork.Set<T>().Remove(model);
        }

        public T Add<T>(T model) where T : class
        {
            return _unitOfWork.Set<T>().Add(model);
        }
    }
}