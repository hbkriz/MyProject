using System.Collections.Generic;

namespace MyProjectApi.DTOs
{
    public class ContractWithClientDto
    {
        public int ContractId { get; set; }
        public string ContractReference { get; set; }
        public virtual List<ClientDto> Clients { get; set; }
    }
}