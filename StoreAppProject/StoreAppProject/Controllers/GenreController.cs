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
    public class GenreController : ApiController
    {
        // GET api/genre
        public IEnumerable<Genre> Get()
        {
            return GenreRepository.GetGenres();
        }

        // GET api/genre/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/genre
        public void Post([FromBody]string value)
        {
        }

        // PUT api/genre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/genre/5
        public void Delete(int id)
        {
        }
    }
}
