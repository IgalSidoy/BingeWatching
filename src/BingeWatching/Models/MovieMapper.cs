using Newtonsoft.Json.Linq;

namespace BingeWatching.Models
{
    public class MovieMapper
    {
        public static Movie Map(MovieResponse source)
        {
            var reuslt = new Movie()
            {
                Id = source.Id,
                ImdbRating = source.ImdbRating,
                Overview = source.Overview,
                Title = source.Title
            };
            return reuslt;
        }
    }
}