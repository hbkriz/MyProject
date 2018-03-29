using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models;

namespace MyProjectOData.DAL
{
    public class ProjectContext: DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        

        public DbSet<Blog> Blogs { get; set; }
    }
}