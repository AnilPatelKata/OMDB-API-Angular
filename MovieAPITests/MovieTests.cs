using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using Xunit;

namespace MovieAPITests
{
    public class MovieTests
    {
        [Fact]
        public void GetMovieFromSearchQueryForStep2()
        {
            var url = "http://www.omdbapi.com/?apikey=8a75ab28&t=harry+potter";
            var checkApi = OmdbWebRequest(url);
            var getFilmNameValue = checkApi.First.First.Value<string>().ToString();
            var filmName = "Harry Potter and the Deathly Hallows: Part 2";
            Assert.Matches(filmName, getFilmNameValue);
        }

        [Fact]
        public void GetTotalResultsOfASearchQuery()
        {
            var url = "http://www.omdbapi.com/?apikey=8a75ab28&s=Batman&page=2";
            var checkApi = OmdbWebRequest(url);
            var getSeasonNumber = checkApi.GetValue("totalResults").Value<int>().ToString();
            var seasonNumber = "380";
            Assert.Equal(seasonNumber, getSeasonNumber);
        }

        [Fact]
        public void SearchForASeasonOfAPrograme()
        {
            var url = "http://www.omdbapi.com/?apikey=8a75ab28&t=big+bang+theory&Season=3";
            var checkApi = OmdbWebRequest(url);
            var getSeasonNumber = checkApi.GetValue("Season").Value<int>().ToString();
            var seasonNumber = "3";
            Assert.Equal(seasonNumber, getSeasonNumber);
        }

        [Fact]
        public void SearchForFilmById()
        {
            var url = "http://www.omdbapi.com/?apikey=8a75ab28&i=tt1285016";
            var checkApi = OmdbWebRequest(url);
            var getFilmNameValue = checkApi.First.First.Value<string>().ToString();
            var filmName = "The Social Network";
            Assert.Equal(filmName, getFilmNameValue);
        }

        [Fact]
        public void SearchForFilmWithNoIdOrTitleReturnsFalse()
        {
            var url = "http://www.omdbapi.com/?apikey=8a75ab28";
            var checkApi = OmdbWebRequest(url);
            var getFilmNameValue = checkApi.First.First.Value<string>().ToString();
            var filmName = "False";
            Assert.Equal(filmName, getFilmNameValue);
        }


        private JObject OmdbWebRequest(string url)
        {
            var jsonObject = new JObject();

            if (!string.IsNullOrWhiteSpace(url))
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json; encoding='utf-8'";
                using (var response = request.GetResponse())
                {
                    using (var rd = new StreamReader(response.GetResponseStream()))
                    {
                        var soapResult = rd.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(soapResult))
                        {
                            jsonObject = JObject.Parse(soapResult);
                            return jsonObject;
                        }
                    }
                }
            }

            return jsonObject;
        }
    }
}
