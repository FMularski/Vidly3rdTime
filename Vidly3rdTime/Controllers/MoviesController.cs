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
            return View();
        }

        public ActionResult New()
        {
            var vm = new MovieFormViewModel
            {
                Genres = Context.Genres.ToList()
            };

            return View("MovieForm", vm);
        }

        public ActionResult Save(MovieFormViewModel vm)
        {
            if ( !ModelState.IsValid)
            {
                vm.Genres = Context.Genres.ToList();
                return View("MovieForm", vm);
            }

            if (vm.Id == 0)
                Context.Movies.Add( new Movie
                {
                    Name = vm.Name,
                    DateRealesed = vm.DateReleased.Value,
                    DateAdded = DateTime.Now,
                    GenreId = vm.GenreId.Value,
                    NumberInStock = vm.NumberInStock.Value
                });
            else
            {
                var movieInDb = Context.Movies.Single(m => m.Id == vm.Id);
                movieInDb.Name = vm.Name;
                movieInDb.DateRealesed = vm.DateReleased.Value;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreId = vm.GenreId.Value;
                movieInDb.NumberInStock = vm.NumberInStock.Value;
            }

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit( int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var vm = new MovieFormViewModel(movie)
            {
                Genres = Context.Genres.ToList()
            };

            return View("MovieForm", vm);
        }
    }
}