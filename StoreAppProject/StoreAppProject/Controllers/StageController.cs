using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreAppPortLibrary;
using StoreAppProject.Models.DAL;

namespace StoreAppProject.Controllers
{
    public class StageController : ApiController
    {
        // GET api/stage
        public IEnumerable<Stage> Get()
        {
            return StageRepository.GetAllStages();
        }

        // GET api/stage/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/stage
        public void Post([FromBody]string value)
        {
        }

        // PUT api/stage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/stage/5
        public void Delete(int id)
        {
        }
    }
}
