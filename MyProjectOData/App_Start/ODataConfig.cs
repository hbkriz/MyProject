using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
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
                routeName: "OData0",
                routePrefix: "Test",
                model: GetDefaultModels());

            config.MapODataServiceRoute(
                routeName: "OData1",
                routePrefix: "Project",
                model: GetProjectModels());

            config.MapODataServiceRoute(
                routeName: "OData2",
                routePrefix: "CAAI",
                model: GetCaaiModels());

            config.MapODataServiceRoute(
                routeName: "OData3",
                routePrefix: "CVC",
                model: GetCvcModels());
        }

        private static IEdmModel GetDefaultModels()
        {
            var builder = new ODataConventionModelBuilder();
            //var movies = builder.EntitySet<Movie>("Movies");
            //movies.EntityType.Ignore(emp => emp.Director);
            builder.EntitySet<Movie>("Movies");
            builder.EntitySet<Product>("Products");
            return builder.GetEdmModel();
        }

        private static IEdmModel GetProjectModels()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Blog>("Blogs");
            return builder.GetEdmModel();
        }

        private static IEdmModel GetCvcModels()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.CVC.Contract>("CvcContract");
            builder.EntitySet<Models.CVC.StaticInfo>("CvcStaticInfo");
            return builder.GetEdmModel();
        }

        private static IEdmModel GetCaaiModels()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.ClientInvoicing.Client>("ClientInvoicingClient");
            builder.EntitySet<Models.ClientInvoicing.Contract>("ClientInvoicingContract");
            return builder.GetEdmModel();
        }

    }
}