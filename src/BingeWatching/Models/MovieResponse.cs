using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BingeWatching.Models
{
    public class MovieResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        
        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }
        
        [JsonPropertyName("classification")]
        public string Classification { get; set; }
        
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
        
        [JsonPropertyName("released_on")]
        public DateTime ReleasedOn { get; set; }
        
        [JsonPropertyName("has_poster")]
        public bool HasPoster { get; set; }
        
        [JsonPropertyName("has_backdrop")]
        public bool HasBackdrop { get; set; }
        
        [JsonPropertyName("imdb_rating")]
        public float ImdbRating { get; set; }
        
        [JsonPropertyName("rt_critics_rating")]
        public string RtCriticsRating { get; set; }
        
        [JsonPropertyName("genres")]
        public int[] Genres { get; set; }
        
        [JsonPropertyName("watchlisted")]
        public string WatchListed { get; set; }
        
        [JsonPropertyName("seen")]
        public bool Seen { get; set; }
        
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }
 
    }
}