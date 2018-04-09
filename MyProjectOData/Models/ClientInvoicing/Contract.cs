using System.Collections.Generic;

namespace MyProjectOData.Models.ClientInvoicing
{
    public class Contract
    {
        public int ContractId { get; set; }
        public string ContractReference { get; set; }
        public string CostCentre { get; set; }
        public virtual List<Client> Clients { get; set; }
    }
}