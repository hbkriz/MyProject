namespace MyProjectApi.DAL
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : class;
        void Save();
    }
}