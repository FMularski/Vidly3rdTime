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
            return View();
        }

        public ActionResult New()
        {
            var vm = new CustomerFormViewModel()
            {
                MembershipTypes = Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", vm);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel vm)
        {
            if ( !ModelState.IsValid)
            {
                vm.MembershipTypes = Context.MembershipTypes.ToList();
                return View("CustomerForm", vm);
            }

            if ( vm.Id == 0)
                Context.Customers.Add( vm.CustomerBasedOnViewModel);
            else
            {
                var customerInDb = Context.Customers.Single(c => c.Id == vm.Id);

                customerInDb.Name = vm.CustomerBasedOnViewModel.Name;
                customerInDb.Birthdate = vm.CustomerBasedOnViewModel.Birthdate;
                customerInDb.MembershipTypeId = vm.CustomerBasedOnViewModel.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = vm.CustomerBasedOnViewModel.IsSubscribedToNewsletter;
            }
            
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var vm = new CustomerFormViewModel (customer)
            {
                MembershipTypes = Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", vm);
        }
    }
}