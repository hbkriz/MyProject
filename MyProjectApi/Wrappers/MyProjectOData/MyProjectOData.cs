﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MyProjectApi.DTOs;
using MyProjectApi.Wrappers.ConfigurationManagerWrapper;
using MyProjectApi.Wrappers.HttpClientWrapper;

namespace MyProjectApi.Wrappers.MyProjectOData
{
    public class MyProjectOData: IMyProjectOData
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public MyProjectOData(IConfigurationManagerWrapper configurationManager, IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _httpClientWrapper.Initialize(configurationManager.GetAppSetting("MyProjectODataUrl"), "My Project OData");
        }
        
        public Task<IEnumerable<BlogDto>> GetAllBlogs()
        {
            var odataMethod = string.Format("CAAI/ClientInvoicingContract");
            return _httpClientWrapper.GetAsync<IEnumerable<BlogDto>>(odataMethod);
        }

        public Task<BlogDto> GetBlog(string contractNumber)
        {
            var odataMethod = string.Format("CAAI/ClientInvoicingContract('{0}')", contractNumber);
            return _httpClientWrapper.GetAsync<BlogDto>(odataMethod);
        }

    }
}