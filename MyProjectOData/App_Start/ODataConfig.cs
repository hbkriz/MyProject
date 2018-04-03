﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using MyProjectOData.Models;
using MyProjectOData.Models.CVC;
using MyProjectOData.Models.Project;
using MyProjectOData.Models.Test;

namespace MyProjectOData
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); //new line
            config.MapODataServiceRoute(
                routeName: "ProjectODataRoute",
                routePrefix: "Project",
                model: GetDefaultModel());
        }

        private static IEdmModel GetDefaultModel()
        {
            var builder = new ODataConventionModelBuilder();
            //builder.EnableLowerCamelCase();
            
            //var movies = builder.EntitySet<Movie>("Movies");
            //movies.EntityType.Ignore(emp => emp.Director);
            
            builder.EntitySet<Blog>("Blogs");
            builder.EntitySet<Contract>("CvcContracts");

            builder.EntitySet<Movie>("Movies");
            builder.EntitySet<Product>("Products");

            return builder.GetEdmModel();
        }

    }
}