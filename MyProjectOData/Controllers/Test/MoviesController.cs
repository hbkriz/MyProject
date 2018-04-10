using System.Linq;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.Models.Test;
using MyProjectOData.Retrievers.Test;

namespace MyProjectOData.Controllers.Test
{
    public class MoviesController : ODataController
    {
        private readonly TestDataService _service;


        private MoviesController()
        {
            _service = new TestDataService();
        }

        [EnableQuery]
        public IQueryable<Movie> Get()
        {
            return _service.Movies;
        }

        [EnableQuery]
        public SingleResult<Movie> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_service.Movies.Where(c => c.Id == key));
        }
    }
}