namespace MyProjectBusinessLayer.Generic
{
    public interface ICreator<TModel, TViewModel> : ICreator<TModel>
    {
        TViewModel Create(TViewModel vm);
    }

    public interface ICreator<TModel>
    {
        TModel Create(TModel model);
    }
}