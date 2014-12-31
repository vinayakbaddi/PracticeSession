using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class DifferentActionController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            return Data.GetProducts();
        }
    }
}
