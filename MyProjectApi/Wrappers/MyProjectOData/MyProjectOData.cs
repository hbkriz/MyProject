using System.Collections.Generic;
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
        
        public Task<IEnumerable<ContractDto>> GetAllContracts()
        {
            var odataMethod = string.Format("CAAI/ClientInvoicingContract");
            return _httpClientWrapper.GetAsync<IEnumerable<ContractDto>>(odataMethod);
        }

        public Task<ContractDto> GetContract(string contractNumber)
        {
            var odataMethod = string.Format("CAAI/ClientInvoicingContract('{0}')", contractNumber);
            return _httpClientWrapper.GetAsync<ContractDto>(odataMethod);
        }

    }
}