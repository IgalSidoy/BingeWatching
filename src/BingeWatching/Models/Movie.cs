namespace BingeWatching.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public float ImdbRating  { get; set; }
        public int UserRating { get; set; }
    }
}