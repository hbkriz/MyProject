using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models.ClientInvoicing;

namespace MyProjectOData.DAL.Contexts
{
    public class ClientInvoiceContext : DbContext
    {
        public ClientInvoiceContext() : base("ClientInvoiceContext")
        {
            Database.SetInitializer<ClientInvoiceContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}