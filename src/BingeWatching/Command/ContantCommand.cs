using BingeWatching.DataAccess;
using BingeWatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingeWatching.Command
{
    public  class ContantCommand
    {
        public static Movie ExecuteHighRatingMovie()
        {

            var currentUser = DataBase.GetCurrentUser();

            var recommendations = currentUser.Recommendations;

 
            foreach(var follower in currentUser.Following)
            {
                for (int i = 10; i > 0; i--)
                {
                    if (!follower.Value.History.ContainsKey(i))
                        continue;
                    
                    if (recommendations.ContainsKey(i))
                        recommendations[i].AddRange(follower.Value.History[i]);                    
                    else
                        recommendations.Add(i, follower.Value.History[i]);
                }
            }
            currentUser.SetCalculatedRecommendations(recommendations);
     

            Movie selectedMovie = null;
            
            for (int i = 10; i > 0; i--)
            {
                if (!currentUser.Recommendations.ContainsKey(i))
                    continue;

                var movies = currentUser.Recommendations[i];

                selectedMovie = movies.FirstOrDefault();

                if (!currentUser.WatchedMovies.ContainsKey(selectedMovie.Id))
                {
                    currentUser.AddToWatched(selectedMovie.Id);
                    break;
                }
                else
                    selectedMovie = null;
            }
            return selectedMovie;

        }
    }
}
