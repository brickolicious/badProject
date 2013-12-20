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
    public class FestivalController : ApiController
    {
        // GET api/festival
        public IEnumerable<DateTime> Get()
        {
            return FestivalRepository.GetFestivalDays();
        }

        // GET api/festival/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/festival
        public void Post([FromBody]string value)
        {
        }

        // PUT api/festival/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/festival/5
        public void Delete(int id)
        {
        }
    }
}
