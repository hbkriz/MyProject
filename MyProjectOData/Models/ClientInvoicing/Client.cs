namespace MyProjectOData.Models.ClientInvoicing
{
    public class Client
    {
        public int ClientId { get; set; }
        public int ContractId { get; set; }
        public string ClientName { get; set; }

        public string ContactName { get; set; }
    }
}