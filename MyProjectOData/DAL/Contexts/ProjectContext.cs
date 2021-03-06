﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyProjectOData.Models.Project;

namespace MyProjectOData.DAL.Contexts
{
    public class ProjectContext: DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
            Database.SetInitializer<ProjectContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}