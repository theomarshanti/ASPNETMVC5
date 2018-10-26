using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET: /Movies
        public IEnumerable<MovieDto> GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies.Include(m=>m.Genre).Where(m => m.NumberAvailable>0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery.Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET: /Movies/1
        public MovieDto GetMovies(int id)
        {
            var selectedMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (selectedMovie == null)
            {
                throw new IndexOutOfRangeException();
            }
            return Mapper.Map<MovieDto>(selectedMovie);
        }


        //POST: /Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT: /Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Movie selectedMovieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (selectedMovieInDb == null){
                return NotFound();
            }
            Mapper.Map<MovieDto, Movie>(movieDto, selectedMovieInDb);
            _context.SaveChanges();
            return Ok(movieDto);
        }


        //DELETE: /Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie selectedMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (selectedMovie == null)
            {
                return NotFound();
            } else
            {
                _context.Movies.Remove(selectedMovie);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
