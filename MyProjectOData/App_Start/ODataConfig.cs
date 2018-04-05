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
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

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
            var builder = new ODataConventionModelBuilder
            {
                Namespace = "ClientService"
            };

            builder.EntitySet<Models.ClientInvoicing.Client>("ClientInvoicingClient");
            
            var contracts = builder.EntitySet<Models.ClientInvoicing.Contract>("ClientInvoicingContract");

            //Key for an Entity Model
            var contract = contracts.EntityType;
            contract.HasKey(p => p.ContractReference);

            BuildFunctionsAndActions(builder);

            return builder.GetEdmModel();
        }

        private static void BuildFunctionsAndActions(ODataModelBuilder builder)
        {
            // unbound and return the primitive type
            builder.EntityType<Models.ClientInvoicing.Contract>().Function("GetCircles").Returns<int>();
            builder.EntityType<Models.ClientInvoicing.Contract>().Collection.Function("GetTriangles").Returns<int>();

            // unbound and return the entity
            //builder.Function("GetCircles").ReturnsFromEntitySet<Shape>("Shapes");

            //builder.EntityType<Models.ClientInvoicing.Client>()
            //    .Action("Rate")
            //    .Parameter<double>("Rating");

            builder.EntityType<Models.ClientInvoicing.Client>().Collection
                .Function("GetHighestRating")
                .Returns<double>();

            var function = builder.EntityType<Models.ClientInvoicing.Client>().Collection.Function("GetHighestClientRating");
            function.Parameter<int>("Id");
            function.Parameter<int>("Year");
            function.Returns<double>();

            var testCollectionFunction = builder.EntityType<Models.ClientInvoicing.Client>().Action("GetEvenNumbers");
            testCollectionFunction.CollectionParameter<int>("numbers");
            testCollectionFunction.ReturnsCollection<int>();
        }

        #region ODATA Commands on Swagger
        //$expand
        //    Posts($select= Title;$expand=TypeOfPosts($select= Type))

        //$select
        //ColumnName,...
        //ContractId, ContractReference

        //$top, $skip
        //1,2,...

        //$filter
        //ContractReference eq 'M00350'
        //contains(ContractReference, 'M00')

        //nested $filter
        //$expand=Trips($filter= Name eq 'Trip in US')
        //$expand=Clients($filter= contains(ContactName, 'Tes'))

        //$orderby
        //Name desc
        //Name asc or Name

        //$count
        //true - gives the count of the response
        #endregion

    }
}