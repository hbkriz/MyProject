using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public T Get<T>(Expression<Func<T, bool>> match) where T : class
        {
            return _context.Set<T>().SingleOrDefault(match);
        }
        
        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class
        {
            return condition != null ? _context.Set<T>().Where(condition) : _context.Set<T>();
        }

        public T Update<T>(T model) where T : class
        {
            _context.Set<T>().Attach(model);
            _context.Entry(model).State = EntityState.Modified; //Tracking
            return model;
        }

        public void Delete<T>(T model) where T : class
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(model);
            }
            _context.Set<T>().Remove(model);
        }

        public T Add<T>(T model) where T : class
        {
            return _context.Set<T>().Add(model);
        }

        public void Save()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        #region Dispose being used for context being called
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}