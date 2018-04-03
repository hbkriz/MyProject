using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyProjectOData.DAL
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext: DbContext
    {
        protected TDbContext _dbContext;
        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
        public DbEntityEntry DbEntityEntry<T>(T entity) where T : class
        {
            return _dbContext.Entry(entity);
        }

        #region Dispose being used for context being called
        private bool _disposed;

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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