﻿using System.Data.Entity.Migrations;
using MyProjectApi.DAL;
using MyProjectApi.Models;

namespace MyProjectApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Blogs.AddOrUpdate(
              p => p.Name,
              new Blog { Name = "Andrew Peters" },
              new Blog { Name = "Brice Lambson" }
            );
        }
    }
}