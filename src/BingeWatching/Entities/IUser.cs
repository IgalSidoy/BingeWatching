using BingeWatching.Models;
using System.Collections.Generic;

namespace BingeWatching.User
{
    public interface IUser
    {
        public void AddToHistory(int userRating, Movie movie);

        public List<Movie> GetHistory();
    }
}