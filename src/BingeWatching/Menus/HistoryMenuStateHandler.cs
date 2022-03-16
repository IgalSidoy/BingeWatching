using BingeWatching.DataAccess;
using System;
using System.Text;

namespace BingeWatching.Menus
{
    public class HistoryMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.History;
        }

        public void Handle()
        {
            var currentUser = DataBase.GetCurrentUser();
            Console.WriteLine("History");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("User -- "+ currentUser.Id);
            Console.WriteLine("");

            foreach (var movie in currentUser.GetHistory())
            {
                Console.WriteLine("---------------------------------------------------");
                var sb = new StringBuilder();
                sb.AppendLine("Title - "+movie.Title);
                sb.AppendLine("Overview - " + movie.Overview);
                sb.AppendLine("ImdbRating - "+ movie.ImdbRating.ToString());
                sb.AppendLine("UserRating - " + movie.UserRating.ToString());
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(sb.ToString());
            }

        }
    }
}