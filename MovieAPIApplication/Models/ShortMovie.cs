using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIApplication.Models
{
    public class ShortMovie
    {
        [JsonProperty("Title")]
        public string Name { get; set; }
        [JsonProperty("Country")]
        public string CountryReleased { get; set; }


    }
}
