using MovieAPIApplication.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace MovieAPIApplication.Services
{
    public class MovieInformationService : IMovieInformationService
    {
        public Movie GetMovieFullInformation(string movieTitle)
        {
            var model = GetMovieInformation(movieTitle, new Movie());
            if (model != null)
            {
                return model;
            }

            return model;
        }

        public ShortMovie GetMovieShortInformation(string movieTitle)
        {
            var shortInformationViewModel = GetShortMovieInformation(movieTitle, new ShortMovie());
            if (shortInformationViewModel != null)
            {
                return shortInformationViewModel;
            }

            return shortInformationViewModel;
        }

        private Movie GetMovieInformation(string title, Movie getMovie)
        {
            var soapResult = OmdbWebRequest(title);

            if (!string.IsNullOrWhiteSpace(soapResult))
            {
                getMovie = JsonConvert.DeserializeObject<Movie>(soapResult);
            }
            return getMovie;
        }

        private ShortMovie GetShortMovieInformation(string title, ShortMovie getMovie)
        {
            var soapResult = OmdbWebRequest(title);

            if (!string.IsNullOrWhiteSpace(soapResult))
            {
                getMovie = JsonConvert.DeserializeObject<ShortMovie>(soapResult);
            }
            return getMovie;
        }

        private string OmdbWebRequest(string title)
        {
            var soapResult = string.Empty;

            var url = "http://www.omdbapi.com/?apikey=8a75ab28";
            url += "&t=" + HttpUtility.UrlEncode(title);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json; encoding='utf-8'";
            using (var response = request.GetResponse())
            {
                using (var rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(soapResult))
                    {
                        return soapResult;
                    }
                }
            }
            return soapResult;
        }
    }
}
