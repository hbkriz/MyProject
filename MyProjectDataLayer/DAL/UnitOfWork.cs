using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyProjectDataLayer.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }
        
        public void Save()
        {
            _context.Save();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }
        public DbEntityEntry DbEntityEntry<T>(T entity) where T : class
        {
            return _context.Entry(entity);
        }

        #region Dispose being used for context being called
        private bool _disposed;

        protected void Dispose(bool disposing)
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