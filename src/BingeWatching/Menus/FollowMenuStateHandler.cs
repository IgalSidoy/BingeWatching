using BingeWatching.Command;
using System;
namespace BingeWatching.Menus
{
    public class FollowMenuStateHandler: IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Follow;
        }

        public void Handle()
        {
            var followActions = GetAllPossibleFollowActions();
            Console.WriteLine("Please choose:");
            Console.WriteLine("---------------------------------------------------------------------");
            
            foreach (var contentType in followActions)
            {
                Console.Write($"{Char.ToLower((char)contentType)} - {contentType}  |  ");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();
            var choiceRes = (FollowerOptions)Enum.ToObject(typeof(FollowerOptions), (int)Console.ReadKey().KeyChar);
           
            FollowCommand.Execute(choiceRes);

            Console.ReadLine();
        }

        private FollowerOptions[] GetAllPossibleFollowActions() =>
          (FollowerOptions[])Enum.GetValues(typeof(FollowerOptions));
    }
}