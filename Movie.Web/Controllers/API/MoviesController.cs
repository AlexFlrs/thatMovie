using Movie.Models.Domain;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie.Web.Controllers.API
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        // GetAll
        [Route, HttpGet]
        public List<MovieDomain> GetAll()
        {
            List<MovieDomain> movies = ThatMovieService.GetAll();
            return movies;
           
        }

        // GETById: api/Movies/5
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var movie = new MovieDomain();
            return Request.CreateResponse(HttpStatusCode.OK); 
        }

        // POST: api/Movies
        [Route,HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Movies/5
        [Route("{id:int}"),HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Movies/5
        [Route("{id:int}"),HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
