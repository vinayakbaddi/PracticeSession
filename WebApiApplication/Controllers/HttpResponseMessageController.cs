using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class HttpResponseMessageController : ApiController
    {

        public void PostData()
        {
            //The below is the Response for this method
            //HTTP/1.1 204 No Content
            //Server: Microsoft-IIS/8.0
            //Date: Mon, 27 Jan 2014 02:13:26 GMT            
        }

        public HttpResponseMessage GetResponse()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Value");
            response.Content = new StringContent("A Sample String content", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };

            return response;
        }

        public HttpResponseMessage Get()
        {
            
            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Data.GetProducts());
            return response;
        }

    }
}
