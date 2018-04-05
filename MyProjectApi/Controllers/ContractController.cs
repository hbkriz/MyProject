using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyProjectApi.DTOs;
using MyProjectApi.Wrappers.ConfigurationManagerWrapper;
using MyProjectApi.Wrappers.HttpClientWrapper;
using MyProjectApi.Wrappers.MyProjectOData;
using MyProjectBusinessLayer.ViewModels;

namespace MyProjectApi.Controllers
{
    public class ContractController : ApiController
    {
        private readonly IMyProjectOData _projectOData;
        public ContractController() : this(new MyProjectOData(new ConfigurationManagerWrapper(), new HttpClientWrapper()))
        {

        }

        public ContractController(IMyProjectOData projectOData)
        {
            _projectOData = projectOData;
        }


        [Route("GetAll")]
        public async Task<IEnumerable<BlogDto>> GetAll()
        {
            return await _projectOData.GetAllBlogs();
        }

        [Route("Get")]
        public async Task<BlogDto> Get(string contractNumber)
        {
            return await _projectOData.GetBlog(contractNumber);
        }

    }
}
