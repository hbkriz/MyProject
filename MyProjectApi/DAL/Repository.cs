using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyProjectApi.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _entities;

        public Repository(IUnitOfWork unitOfWork)
        {
            _entities = unitOfWork.Set<T>();
        }
        
        public T Get(Expression<Func<T, bool>> match)
        {
            return _entities.SingleOrDefault(match);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null)
        {
            return condition != null ? _entities.Where(condition) : _entities;
        }

        //public T Update(T updated, params object[] keyValues)
        //{
        //    if (updated == null) return null;

        //    var existing = _entities.Find(keyValues);
        //    if (existing == null) return null;

        //    _context.Entry(existing).CurrentValues.SetValues(updated);
        //    return existing;
        //}

        //public void Delete(Expression<Func<T, bool>> condition)
        //{
        //    var model = _entities.SingleOrDefault(condition);
        //    if (model == null) throw new NullReferenceException(typeof(T) + " model not found");
        //    if (_context.Entry(model).State == EntityState.Detached)
        //    {
        //        _entities.Attach(model);
        //    }
        //    _entities.Remove(model);
        //}

        //public T Add(T model)
        //{
        //    return _entities.Add(model);
        //}
    }
}