using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3rdTime.Models;
using System.Data.Entity;
using Vidly3rdTime.ViewModels;

namespace Vidly3rdTime.Controllers
{
    public class MoviesController : Controller
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

        public ActionResult Index()
        {
            return View(Context.Movies.Include(m => m.Genre));
        }

        public ActionResult New()
        {
            var vm = new MovieFormViewModel
            {
                Genres = Context.Genres.ToList()
            };

            return View("MovieForm", vm);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                Context.Movies.Add(movie);
            else
            {
                var movieInDb = Context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.DateRealesed = movie.DateRealesed;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit( int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var vm = new MovieFormViewModel
            {
                Movie = movie,
                Genres = Context.Genres.ToList()
            };

            return View("MovieForm", vm);
        }
    }
}