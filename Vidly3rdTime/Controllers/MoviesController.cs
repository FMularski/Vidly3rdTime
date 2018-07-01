using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3rdTime.Models;
using System.Data.Entity;

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

        public ActionResult Details( int id)
        {
            var movie = Context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}