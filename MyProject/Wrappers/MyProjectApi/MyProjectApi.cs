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

    }
}