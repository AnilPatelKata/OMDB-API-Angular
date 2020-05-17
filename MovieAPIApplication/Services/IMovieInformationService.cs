using MovieAPIApplication.Models;

namespace MovieAPIApplication.Services
{
    public interface IMovieInformationService
    {
        Movie GetMovieFullInformation(string movieTitle);
        ShortMovie GetMovieShortInformation(string movieTitle);
    }
}
