using System.Threading.Tasks;

namespace MyProjectBusinessLayer.Generic
{
    public interface IDeletor<TModel> : IDeletor
    {
    }

    public interface IDeletor
    {
        void Delete(object id);
    }
}