﻿using System.Threading.Tasks;

namespace MyProjectBusinessLayer.Generic
{
    public interface IEditor<TModel, TViewModel> : IEditor<TModel>
    {
        TViewModel Update(TViewModel source, object id);
    }

    public interface IEditor<TModel>
    {
        TModel Update(TModel source);
    }
}