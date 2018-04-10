using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using MyProjectOData.DAL;
using MyProjectOData.DAL.Contexts;
using MyProjectOData.Models.ClientInvoicing;
using MyProjectOData.Retrievers.ClientInvoicing;

namespace MyProjectOData.Controllers.ClientInvoicing
{
    public class ClientInvoicingClientController : ODataController
    {
        private readonly IClientRetriever _retriever;

        public ClientInvoicingClientController()
        {
            _retriever = new ClientRetriever(new Repository(new BaseContext<ClientInvoiceContext>(new ClientInvoiceContext())));
        }

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(_retriever.GetAll(null));
        }

        [EnableQuery]
        public IHttpActionResult Get(int key)
        {
            var result = _retriever.GetAll(p => p.ContractId == key);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetHighestRating()
        {
            return Ok(100.5);
        }

        [HttpGet]
        public IHttpActionResult GetHighestClientRating(int Id, int Year)
        {
            return Ok(100.5);
        }

        [HttpPost]
        public IHttpActionResult GetEvenNumbers(ODataActionParameters parameter)
        {
            IEnumerable<int> numbers = parameter["numbers"] as IEnumerable<int>;
            List<int> evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return Ok(evenNumbers);
        }
    }
}
