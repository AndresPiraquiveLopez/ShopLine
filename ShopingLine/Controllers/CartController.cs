﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopingLine.Controllers
{
    public class CartController : ApiController
    {
        // GET: api/Cart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
        }
    }
}
