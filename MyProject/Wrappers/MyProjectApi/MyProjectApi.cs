using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.DTOs;
using MyProject.Wrappers.ConfigurationManagerWrapper;
using MyProject.Wrappers.HttpClientWrapper;

namespace MyProject.Wrappers.MyProjectApi
{
    public class MyProjectApi: IMyProjectApi
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public MyProjectApi(IConfigurationManagerWrapper configurationManager, IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _httpClientWrapper.Initialize(configurationManager.GetAppSetting(Constants.Constants.MyProjectApiUrlKey),
                Constants.Constants.MyProjectApiName);
        }

        public Task<IEnumerable<BlogDto>> GetAllBlogs()
        {
            var apiMethod = string.Format("Blog/GetAll");
            return _httpClientWrapper.GetAsync<IEnumerable<BlogDto>>(apiMethod);
        }

        public Task<BlogDto> GetBlog(int id)
        {
            var apiMethod = string.Format("Blog/Get?id={0}", id);
            return _httpClientWrapper.GetAsync<BlogDto>(apiMethod);
        }

        public Task DeleteBlog(int id)
        {
            var apiMethod = string.Format("Blog/Delete?id={0}", id);
            return _httpClientWrapper.DeleteAsync<BlogDto>(apiMethod);
        }

        public Task<BlogDto> CreateBlog(BlogDto blog)
        {
            var apiMethod = string.Format("Blog/Create");
            return _httpClientWrapper.PostAsJsonAsync<BlogDto>(apiMethod, blog);
        }

        public Task<BlogDto> UpdateBlog(int id, BlogDto blog)
        {
            var apiMethod = string.Format("Blog/Update?id={0}", id);
            return _httpClientWrapper.PutAsJsonAsync<BlogDto>(apiMethod, blog);
        }
    }
}