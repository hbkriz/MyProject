namespace MyProjectOData.Models.ClientInvoicing
{
    public class Retention
    {
        public int RetentionId { get; set; }
        public int ReceivableId { get; set; }
        public decimal RateThisCertificate { get; set; }
        public virtual Receivable Receivable { get; set; }
    }
}