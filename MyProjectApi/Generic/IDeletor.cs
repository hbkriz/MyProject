using System.Threading.Tasks;

namespace MyProjectApi.Generic
{
    public interface IDeletor<TModel> : IDeletor
    {
    }

    public interface IDeletor
    {
        void Delete(object id);
    }
}