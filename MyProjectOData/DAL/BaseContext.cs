using System;
using System.Data.Entity;

namespace MyProjectOData.DAL
{
    public class BaseContext<TDbContext> : IBaseContext
        where TDbContext: DbContext
    {
        private readonly TDbContext _dbContext;
        public BaseContext(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        #region Dispose used for Context
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