using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // [GET] /rentals
        public IEnumerable<RentalDto> GetRentals()
        {
            //return _context.rentals.toList()
            return null;
        }
        
        // [GET] /rentals/id
        public RentalDto GetRentals(int id)
        {
            //return _context.rentals.FirstOrDefault(r=>r.Id == id)
            return null;
        }

        // [POST] /rentals
        [HttpPost]
        public IHttpActionResult CreateRentals(RentalDto newRentalDto)
        {
            if ( (!ModelState.IsValid) | (newRentalDto.MovieIds.Count==0))
            {
                return BadRequest("Form invalid");    
            }

            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer couldnt be found");
            }


            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
            
            if(movies.Count != newRentalDto.MovieIds.Count)
            {
                return BadRequest("One or more movie IDs are invalid.");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) {
                    return BadRequest("Requested movie is not avaialble");
                }
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }


        // [PUT] /rentals/id
        [HttpPut]
        public void UpdateRentals(int id, RentalDto input)
        {
            //selected = _context.FirstOrDefault(r=>r.Id==id)
            //selected.customer = input.customer
            //selected.Movies = input.movies;
        }


        // [DELETE] /rentals/id
        [HttpDelete]
        public void DeleteRentals(int id)
        {
            //selected = _context.FirstOrDefault()
            //_context.Delete(selected)
        }


    }
}
