using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models;

namespace MyProjectOData.DAL
{
    public class CostValueCompContext : DbContext
    {
        public CostValueCompContext() : base("CostValueCompContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbEntityEntry DbEntityEntry<T>(T entity) where T : class
        {
            return Entry(entity);
        }

        public DbSet<Contract> Contracts { get; set; }
    }
}