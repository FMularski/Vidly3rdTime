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

        public ActionResult New()
        {
            var vm = new CustomerFormViewModel
            {
                MembershipTypes = Context.MembershipTypes.ToList(),
                Customer = new Customer()
            };

            return View("CustomerForm", vm);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if ( customer.Id == 0)
                Context.Customers.Add(customer);
            else
            {
                var customerInDb = Context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var vm = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", vm);
        }
    }
}