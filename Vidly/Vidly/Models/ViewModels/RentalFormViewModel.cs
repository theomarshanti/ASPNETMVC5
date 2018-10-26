using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class RentalFormViewModel
    {
        public List<Customer> AllCustomers { get; set; }
        public List<Movie> AllMovies { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<Movie> Movies { get; set; }
        public List<int> MovieIDs { get; set; }
    }
}