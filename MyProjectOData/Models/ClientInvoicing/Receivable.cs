using System.Collections.Generic;

namespace MyProjectOData.Models.ClientInvoicing
{
    public class Receivable
    {
        public int ReceivableId { get; set; }
        public int ClientId { get; set; }
        public string InvoiceNumber { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Retention> Retentions { get; set; }
    }
}