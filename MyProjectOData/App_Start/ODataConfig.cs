using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using MyProjectDataLayer.Models;
using MyProjectOData.Models;

namespace MyProjectOData
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); //new line
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
            
            builder.EntitySet<Blog>("Blogs");

            return builder.GetEdmModel();
        }
        
    }
}