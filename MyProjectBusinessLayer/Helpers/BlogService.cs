using System.Collections.Generic;
using System.Linq;
using MyProjectBusinessLayer.Helpers.Interfaces;
using MyProjectBusinessLayer.Services.Creators.Interfaces;
using MyProjectBusinessLayer.Services.Deletors.Interfaces;
using MyProjectBusinessLayer.Services.Editors.Interfaces;
using MyProjectBusinessLayer.Services.Retrievers.Interfaces;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Helpers
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
            return _blogRetriever.GetAll(null).ToList();
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            return _blogRetriever.GetAllModels(null).AsQueryable();
        }

        public BlogViewModel Get(int id)
        {
            return _blogRetriever.Get(i => i.BlogId == id);
        }

        public Blog GetBlog(int id)
        {
            return _blogRetriever.GetModel(i => i.BlogId == id);
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