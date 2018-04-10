using System.Data.Entity;

namespace MyProjectOData.DAL
{
    public interface IBaseContext
    {
        IDbSet<T> Set<T>() where T : class;
    }
}