using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieAPIApplication.Models;
using MovieAPIApplication.Services;

namespace MovieAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class MovieSearchController : Controller
    {
        private readonly IMovieInformationService movieInformationService;

        public MovieSearchController(IMovieInformationService movieInformationService)
        {
            this.movieInformationService = movieInformationService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Movie> Movies()
        {
           var movieCollection = new List<Movie>();
           var movieTitle = "harry potter";
           var movie = movieInformationService.GetMovieFullInformation(movieTitle);
           if (movie != null)
           {
               movieCollection.Add(movie);
           }
           return movieCollection;
        }

       
    }
}
