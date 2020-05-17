using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieAPIApplication.Models;
using MovieAPIApplication.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class ShortMovieController : Controller
    {
        private readonly IMovieInformationService movieInformationService;

        public ShortMovieController(IMovieInformationService movieInformationService)
        {
            this.movieInformationService = movieInformationService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ShortMovie> Movies()
        {
            var movieCollection = new List<ShortMovie>();
            var movieTitle = "harry potter";
            var movie = movieInformationService.GetMovieShortInformation(movieTitle);
            if (movie != null)
            {
                movieCollection.Add(movie);
            }
            return movieCollection;
        }
    }
}
