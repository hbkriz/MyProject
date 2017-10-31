using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectApi.Models;

namespace MyProjectApi.DAL
{
    public class Context : DbContext, IUnitOfWork, IDisposable
    {
        public Context() : base("DatabaseContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        #region Dispose being used for context being called
        private bool _disposed;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    base.Dispose();
                }
            }
            _disposed = true;
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}