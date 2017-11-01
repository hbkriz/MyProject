using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyProjectApi.DAL
{
    public interface IUnitOfWork
    {
        void Save();
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry DbEntityEntry<T>(T entity) where T : class;
    }
}