using System.Web;
using System.Web.Http;
using MyProjectOData;
using Swashbuckle.Application;
using Swashbuckle.OData;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MyProjectOData
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MyProjectOData");
                        c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, GlobalConfiguration.Configuration));

                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }
    }
}
