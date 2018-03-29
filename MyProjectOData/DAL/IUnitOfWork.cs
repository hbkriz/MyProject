using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyProjectOData.DAL
{
    public interface IUnitOfWork
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry DbEntityEntry<T>(T entity) where T : class;
    }
}