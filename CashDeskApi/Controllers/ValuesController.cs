using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashDeskApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return value;
        }

        // PUT api/values/5
        [HttpPut]
        public string Put(int id, [FromUri] int par, [FromBody]string value)
        {
            return $"{id}_{value}_{par}";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
