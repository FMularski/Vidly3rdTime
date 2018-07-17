using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3rdTime.Models;
using Vidly3rdTime.Models.DTO;

namespace Vidly3rdTime.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext Context;

        public NewRentalsController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            var customer = Context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = Context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                Context.Rentals.Add(rental);
            }

            Context.SaveChanges();

            return Ok();
        }
    }
}
