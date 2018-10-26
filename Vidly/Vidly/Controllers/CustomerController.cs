using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        private IEnumerable<Customer> HardCodedGetCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {Name="Omar Shanti", Id=1},
                new Customer() {Name="Ragheed Shanti", Id=2}
            };
        }

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // /Customer/
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //Notice that we expose 2 parameters in the definition
            // But with the '?' and the `string`, both are nullable
            // and therefore we won't run into issues if we don't pass them.

            ////Over here the `.Include` pipe specifies we want to eagerly-load info 
            //// for membershiptype.. which entails loading a new table altogether!
            // var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            //// IEnumerable<Customer> customers = GetCustomers();
            //return View(customers);

            //Now that we've updated our View to request data directly from the API,
            // we dont need to pass it any info!
            return View();
        }

        // /Customer/Details/3
        public ActionResult Details(int Id) {
            Customer requested_customer = _context.Customers.FirstOrDefault((c) => c.Id == Id);
            if (requested_customer == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(requested_customer);
            }
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            //Query the Table to see all possible Membership Types

            //Now, for a `New Customer Form`, we will need to show this data,
            // and then collect other data to satisfy the customer model.
            // Therefore, there are 2 models - Customer & MembershipTypes.
            //As no model fully encapsulates all of the Data that we will use
            // in this model, we create a new ViewModel. We call it 
            // `NewCustomerViewModel`
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        //Can only be called with HttpPost.. Not HttpGet
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Save(Customer customer)
        {
            // Because the Model behind our view is of tiype NewCustomerViewModel
            // MVC framework will automatically map request data to this object. This is "Model-Binding"
            //We also automatically get info about the ModelState
            if (!ModelState.IsValid)
            {
                //Since this is invalid, we simply want to return the same View.
                // We populate the form with the same values the user passes in to the form
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
        
            
            //^ We add the customer to our DB Context.
            // This doesn't write to DB, it just tracks the changes in memory.. 
            // To persist these changes, we must call the below:
            _context.SaveChanges();
            //Here our DB Context goes through the context changes, and generates SQL statements 
            // to persist the data in general.

            //Finally, we re-direct the user back to the list of customers.
            return RedirectToAction("Index", "Customer");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            } else
            {
                //Here we ovveride the default 
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
        }

    }
}