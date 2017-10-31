using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectApi.Models;

namespace MyProjectApi.DAL
{
    public class Context : DbContext, IUnitOfWork
    {
        public Context() : base("DatabaseContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}