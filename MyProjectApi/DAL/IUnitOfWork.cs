using System.Data.Entity;

namespace MyProjectApi.DAL
{
    public interface IUnitOfWork
    {
        void Save();
        IDbSet<T> Set<T>() where T : class;
    }
}