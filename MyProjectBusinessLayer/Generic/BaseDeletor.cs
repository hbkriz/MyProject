using MyProjectDataLayer.DAL;

namespace MyProjectBusinessLayer.Generic
{
    public abstract class BaseDeletor<TModel> : IDeletor<TModel>
        where TModel : class
    {
        protected IRepository Repository { get; set; }

        protected BaseDeletor(IRepository repository)
        {
            Repository = repository;
        }

        public void Delete(object id)
        {
            var model = Repository.Find<TModel>(id);
            Repository.Delete(model);
            Repository.Save();
        }
    }
}