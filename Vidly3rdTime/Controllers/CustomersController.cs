using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3rdTime.Models;
using System.Data.Entity;

namespace Vidly3rdTime.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext Context;

        public CustomersController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        public ActionResult Index()
        {
            return View(Context.Customers.Include( c => c.MembershipType));
        }

        public ActionResult Details(int id)
        {
            var customer = Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}