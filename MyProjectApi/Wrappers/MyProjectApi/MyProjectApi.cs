using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyProjectApi.Wrappers.ConfigurationManagerWrapper;
using MyProjectApi.Wrappers.HttpClientWrapper;
using MyProjectApi.Constants;
using MyProjectApi.DTOs;

namespace MyProjectApi.Wrappers.MyProjectApi
{
    public class MyProjectApi
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
            var apiMethod = string.Format("GetAll");
            return _httpClientWrapper.GetAsync<IEnumerable<BlogDto>>(apiMethod);
        }

    }
}