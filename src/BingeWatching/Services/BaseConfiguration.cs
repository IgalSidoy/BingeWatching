using System.Net.Http;
using Newtonsoft.Json;

using System.Net;
using BingeWatching.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BingeWatching.Services
{
    public class BaseConfiguration
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string Baseurl = "https://api.reelgood.com/v3.0/content/random?availability=onAnySource&nocache=true&region=us&sources=netflix&content_kind=";


        public static Movie GetContent(string type)
        {

            var types = new Dictionary<string, string>();
            types.Add("TvShows","show");
            types.Add("Movies", "movie");
            types.Add("Any", "both");
           if ( types.ContainsKey(type))
            {
                type = types[type];
            }


            var task = Task.Run(() => Client.GetAsync(Baseurl + type));
            task.Wait();
            var response = task.Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                var task2 = Task.Run(() => response.Content.ReadAsStringAsync());
                task2.Wait();
                var jsonString = task2.Result;

                var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(jsonString);

                return MovieMapper.Map(movieResponse);

            }
            return null;  
        }
    }
}