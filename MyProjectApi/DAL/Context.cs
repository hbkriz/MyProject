using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectApi.Models;

namespace MyProjectApi.DAL
{
    public class Context : DbContext
    {
        public Context() : base("DatabaseContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}