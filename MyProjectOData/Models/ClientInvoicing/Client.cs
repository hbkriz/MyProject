using System.Collections.Generic;

namespace MyProjectOData.Models.ClientInvoicing
{
    public class Client
    {
        public int ClientId { get; set; }
        public int ContractId { get; set; }
        public string ClientName { get; set; }

        public string ContactName { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual List<Receivable> Receivables { get; set; }
    }
}