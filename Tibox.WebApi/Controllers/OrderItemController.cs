using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tibox.WebApi.Controllers
{
    public class OrderItemController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {
            return Ok();
        }
    }
}
