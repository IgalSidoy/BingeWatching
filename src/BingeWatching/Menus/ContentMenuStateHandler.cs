using System;
using System.Threading;
using BingeWatching.DataAccess;
using BingeWatching.Services;
using BingeWatching.Command;


namespace BingeWatching.Menus
{
    public class ContentMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Content;
        }

        public void Handle()
        {

            var contentTypes = GetAllPossibleContentActions();
            
            Console.WriteLine("Please choose the content type");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var contentType in contentTypes)
            {
                Console.Write($"{Char.ToLower((char) contentType)} - {contentType}  |  ");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();
            
            var choiceRes = (ContentTypes) Enum.ToObject(typeof(ContentTypes), (int) Console.ReadKey().KeyChar);
            Console.WriteLine();
            var currentUser = DataBase.GetCurrentUser();
            try
            {
                var noRecommendation = false;
                switch (choiceRes)
                {
                    case ContentTypes.TvShows:
                        currentUser.CurrentTitle = BaseConfiguration.GetContent("TvShows");
                        break;
                    case ContentTypes.Movies:
                        currentUser.CurrentTitle = BaseConfiguration.GetContent("Movies");
                        break;
                    case ContentTypes.Any:
                        currentUser.CurrentTitle = BaseConfiguration.GetContent("Any");
                        break;
                    case ContentTypes.FollowRecommendation:
                        currentUser.CurrentTitle = ContantCommand.ExecuteHighRatingMovie();
                        if (currentUser.CurrentTitle == null)
                            noRecommendation = true;
                        break;
                    default:
                        break;
                }

                if (choiceRes == ContentTypes.FollowRecommendation && noRecommendation)
                {
                    Console.WriteLine("No Recommendation found.");

                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("you are watching -- " + currentUser.CurrentTitle.Title);

                    var userRating = CheckWatchStatus();
                    currentUser.CurrentTitle.UserRating = userRating;
                    currentUser.AddToHistory(userRating, currentUser.CurrentTitle);
                    currentUser.CurrentTitle = null;

                }

            }
            catch(Exception e)
            {

                Console.WriteLine("error in fetching the data",e);
 
            }
        }


        private int CheckWatchStatus()
        {

            var finished = false; 
            int rating=-1;
            while (!finished)
            {
                Console.WriteLine(" finished watching (Y/N)");
                var resposne = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.WriteLine();

                if (resposne == "Y")
                {
                    while (!finished)
                    {
                        Console.WriteLine("please add you rating (1-10):");
                        var inputRating = Console.ReadLine();
                    
                        if (int.TryParse(inputRating, out rating) && rating > -1  && rating < 11)
                            finished = true;
                        Console.WriteLine();
                    }
                }
                Thread.Sleep(2000);
            }
            return rating;
        }   


        private ContentTypes[] GetAllPossibleContentActions() =>
            (ContentTypes[]) Enum.GetValues(typeof(ContentTypes));
    }
}