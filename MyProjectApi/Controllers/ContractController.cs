﻿using System;
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


        [Route("GetAllContracts")]
        public async Task<IEnumerable<ContractDto>> GetAll()
        {
            return await _projectOData.GetAllContracts();
        }

        [Route("GetFilteredContractWithClients")]
        public async Task<ContractWithClientDto> Get(string contractNumber)
        {
            return (await _projectOData.GetFilteredContractWithClients(contractNumber)).First();
        }

    }
}
