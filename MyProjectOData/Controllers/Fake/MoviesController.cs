using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.Models;

namespace MyProjectOData.Controllers.Fake
{
    public class MoviesController : ODataController
    {
        private readonly DataService _service;


        private MoviesController()
        {
            _service = new DataService();
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