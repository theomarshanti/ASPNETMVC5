using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Runtime.Caching;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        //Note it derives from APiController

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<CustomerDto> GetCustomers(string query = null)
        {
            //By convention, this will respond to GET /api/customers
            //Here we need to eager-load .. That is what we do with the
            // include pipe(which needed SYstem.Data.Entity)
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            
            var customerDtos = customersQuery.Select(Mapper.Map<Customer, CustomerDto>);
            return customerDtos;

        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            //We need to eagerload 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            CustomerDto customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            // Now this customer has an Id given to it by the DB. We extract it
            //  so we can send it back to the client.
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); //We pass in source object & target object

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
