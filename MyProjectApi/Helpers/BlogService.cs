using System.Collections.Generic;
using MyProjectApi.Helpers.Interfaces;
using MyProjectApi.Services.Creators.Interfaces;
using MyProjectApi.Services.Deletors.Interfaces;
using MyProjectApi.Services.Editors.Interfaces;
using MyProjectApi.Services.Retrievers.Interfaces;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Helpers
{
    public class BlogService : IBlogService
    {
        private readonly IBlogCreator _blogCreator;
        private readonly IBlogDeletor _blogDeletor;
        private readonly IBlogEditor _blogEditor;
        private readonly IBlogRetriever _blogRetriever;

        public BlogService(IBlogCreator blogCreator, IBlogDeletor blogDeletor, IBlogEditor blogEditor, IBlogRetriever blogRetriever)
        {
            _blogCreator = blogCreator;
            _blogDeletor = blogDeletor;
            _blogEditor = blogEditor;
            _blogRetriever = blogRetriever;
        }

        public IList<BlogViewModel> GetAll()
        {
            return _blogRetriever.GetAll(null);
        }

        public BlogViewModel Get(int id)
        {
            return _blogRetriever.Get(i => i.BlogId == id);
        }

        public void Delete(int id)
        {
            _blogDeletor.Delete(id);
        }

        public BlogViewModel Add(BlogViewModel viewModel)
        {
            return _blogCreator.Create(viewModel);
        }

        public BlogViewModel Put(BlogViewModel viewModel, int id)
        {
            return _blogEditor.Update(viewModel, id);
        }

    }
}