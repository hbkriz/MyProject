using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models.CVC;

namespace MyProjectOData.DAL.Contexts
{
    public class CvcContext : DbContext
    {
        public CvcContext() : base("CvcContext")
        {
            Database.SetInitializer<CvcContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<StaticInfo> StaticInfos { get; set; }
    }
}