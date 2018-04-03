using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models;
using MyProjectOData.Models.Project;

namespace MyProjectOData.DAL.Contexts
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