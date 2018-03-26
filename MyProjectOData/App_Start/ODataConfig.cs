using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using MyProjectDataLayer.Models;
using MyProjectOData.Business;
using MyProjectOData.Models;
using Swashbuckle.Application;
using Swashbuckle.OData;

namespace MyProjectOData
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute(
                routeName: "ODataRoute", 
                routePrefix: null, 
                model: GetDefaultModel(),
                defaultHandler: new ODataNullValueMessageHandler() { InnerHandler = new HttpControllerDispatcher(config) });
        }

        private static IEdmModel GetDefaultModel()
        {
            var builder = new ODataConventionModelBuilder();
            //builder.EnableLowerCamelCase();
            
            var movies = builder.EntitySet<Movie>("Movies");
            movies.EntityType.Ignore(emp => emp.Director);


            //builder.EntitySet<Product>("Products");

            builder.EntitySet<Blog>("Blogs");
            builder.EntitySet<Post>("Posts");

            return builder.GetEdmModel();
        }
        
    }
}