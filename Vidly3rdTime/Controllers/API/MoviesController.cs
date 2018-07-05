using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3rdTime.Models;
using Vidly3rdTime.Models.DTO;
using System.Data.Entity;

namespace Vidly3rdTime.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext Context;

        public MoviesController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        // /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(Context.Movies
                .Include( m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>));
        }

        // /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            Context.Movies.Add(movie);
            Context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDTO.Id), movieDTO);
        }

        // /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            var movieInDb = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieInDb);
            Context.SaveChanges();

            return Ok();
        }

        // /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Context.Movies.Remove(movieInDb);
            Context.SaveChanges();

            return Ok();
        }

    }
}
