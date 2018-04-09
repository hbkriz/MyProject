using System.Collections.Generic;
using System.Threading.Tasks;
using MyProjectApi.DTOs;

namespace MyProjectApi.Wrappers.MyProjectOData
{
    public interface IMyProjectOData
    {
        Task<IEnumerable<ContractDto>> GetAllContracts();
        Task<IEnumerable<ContractWithClientDto>> GetFilteredContractWithClients(string contractNumber);
    }
}