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
    public class BandGenreController : ApiController
    {
        // GET api/bandgenre
        public IEnumerable<BandGenre> Get()
        {
            return GenreRepository.GetAllBandGenreCouples();
        }

        // GET api/bandgenre/5
        public IEnumerable<BandGenre> Get(int id)
        {
            return GenreRepository.GetBandGenreCouplesWithGenreID(id);
        }

        // POST api/bandgenre
        public void Post([FromBody]string value)
        {
        }

        // PUT api/bandgenre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bandgenre/5
        public void Delete(int id)
        {
        }
    }
}
