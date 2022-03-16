using System.Collections.Generic;
using BingeWatching.Models;
using BingeWatching.User;

namespace BingeWatching.Entities
{
    public class User : IUser
    {
        private string _id;

        private readonly Dictionary<int, List<Movie>> _history;

        private readonly Dictionary<string, User> _followers;

        private readonly Dictionary<string, User> _following;

        private Dictionary<int, List<Movie>> _recommendations;

        private Dictionary<string, bool> _watchedMovies;

        public Movie CurrentTitle { get; set; }

        public Dictionary<string, bool> WatchedMovies => _watchedMovies;

        public string Id => _id;
        public Dictionary<string, User> Followers => _followers;
        public Dictionary<string, User> Following => _following;

        public Dictionary<int, List<Movie>> History => _history;
        public Dictionary<int, List<Movie>> Recommendations => _recommendations;

        public User(string id)
        {
            _id = id;
            _history = new Dictionary<int, List<Movie>>();
            CurrentTitle = null;
            _followers = new Dictionary<string, User>();
            _following = new Dictionary<string, User>();
            _recommendations = new Dictionary<int, List<Movie>>();
            _watchedMovies = new Dictionary<string, bool>();
        }


        public void AddToHistory(int userRating ,Movie movie)
        {
            if (_history.ContainsKey(userRating))
                _history[userRating].Add(movie);
            
            else
                _history.Add(userRating,new List<Movie>(){movie});
        }


        public List<Movie> GetHistory()
        {
            var history  = new List<Movie>();

            foreach(var key in _history.Keys)
                history.AddRange(_history[key]);
            
            return history;

        }
        public void SetCalculatedRecommendations(Dictionary<int, List<Movie>> recommendations)
        {
            _recommendations = recommendations;
        }

        public void AddToWatched(string movieId)
        {
            if (_watchedMovies.ContainsKey(movieId))
                return;
            _watchedMovies.Add(movieId, true);
        }

    }
}