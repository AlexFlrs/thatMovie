using Movie.Models.Domain;
using Movie.Models.Requests;
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
        public HttpResponseMessage GetAll()
        {
            List<MovieDomain> movies = ThatMovieService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, movies);
           
        }

        // GETById: api/Movies/5
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
           List<MovieDomain> movies = ThatMovieService.GetById(id);
            if(movies == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, movies); 
            }
            
        }

        // POST: api/Movies
        [Route,HttpPost]
        public HttpResponseMessage Create(MovieCreateRequest movieCreateRequest)
        {
            if (movieCreateRequest == null)
            {
                ModelState.AddModelError("", "Missing body data!");
            }
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int newMovieId = ThatMovieService.Create(movieCreateRequest);

            return Request.CreateResponse(HttpStatusCode.OK, newMovieId);
        }

        // PUT: api/Movies/5
        [Route("{id:int}"),HttpPut]
        public HttpResponseMessage Update(int id, MovieUpdateRequest movieUpdateRequest)
        {
            if (movieUpdateRequest == null)
            {
                ModelState.AddModelError("", "No body data!");
            } else if (id != movieUpdateRequest.Id)
            {
                ModelState.AddModelError("id", "ID in the URL does not match the ID in the body");
            }
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ThatMovieService.Update(movieUpdateRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Movies/5
        [Route("{id:int}"),HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            ThatMovieService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
