using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        private IEnumerable<Movie> HardCodedGetMovies()
        {
            return new List<Movie>()
            {
                new Movie() {Name="Usual Suspects", Id=1},
                new Movie() {Name="Get Him To The Greek", Id=2}
            };
        }

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies)) {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        //GET: Movie/Details/2
        public ActionResult Details(int Id)
        {
            IEnumerable<Movie> Movies = _context.Movies.ToList();

            Movie selectedMovie = Movies.FirstOrDefault(m => m.Id == Id);

            if (selectedMovie == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(selectedMovie);
            }
        }

        // GET: Movie/released/{year}/{month}
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>()
        //    {
        //        new Customer(){Id = 1, Name="Omar"},
        //        new Customer(){Id = 1, Name="Ville"}
        //    };
        //    var randomViewModel = new RandomMovieViewModel()
        //    {
        //        Customers = customers,
        //        Movie = movie
        //    };
        //    return View(randomViewModel);

        //}

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var selectedMovie = _context.Movies.FirstOrDefault(c => c.Id == id);
            IEnumerable<Genre> genres = _context.Genres.ToList();
            MovieFormViewModel movie = new MovieFormViewModel()
            {
                Genres = genres,
                Movie = selectedMovie
            };
            return View("MovieForm", movie);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<Genre> genres = _context.Genres.ToList();
                MovieFormViewModel _movie = new MovieFormViewModel()
                {
                    Genres = genres,
                    Movie = movie
                };
                return View("MovieForm", _movie);
            }
            else
            {
                if (movie.Id == 0)
                {
                    _context.Movies.Add(movie);
                }
                else
                {
                    Movie movieInDb = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);

                    movieInDb.Name = movie.Name;
                    movieInDb.Genre = movie.Genre;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
        }
    }
}