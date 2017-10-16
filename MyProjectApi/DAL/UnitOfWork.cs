using System;
using System.Collections.Generic;

namespace MyProjectApi.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public Repository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (Repository<T>)_repositories[type];

            _repositories.Add(type, Activator.CreateInstance(typeof(Repository<>).MakeGenericType(typeof(T)), _context));
            //_repositories.Add(type, new Repository<T>(_context));
            return (Repository<T>)_repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
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