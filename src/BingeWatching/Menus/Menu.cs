using System;
using System.Collections.Generic;
using System.Linq;
using BingeWatching.DataAccess;
using System.Threading.Tasks;
namespace BingeWatching.Menus
{
    public sealed class Menu
    {
        private readonly IList<IMenuStateHandler> _menuStateHandlers = new List<IMenuStateHandler>
        {
            new ContentMenuStateHandler(),
            new SwitchUserMenuStateHandler(),
            new HistoryMenuStateHandler(),
            new ExitMenuStateHandler(),
            new FollowMenuStateHandler()
        };
         

        public async void Run()
        {
            Helpers.LoginSubMenu();
            while (true)
            {
                var menuState = GetMenuState();

                var handler =  _menuStateHandlers.FirstOrDefault(h => h.CanHandle(menuState));
                if (handler == null)
                    throw new NotImplementedException();

                handler.Handle();
         
            }
        }

        private MenuState GetMenuState()
        {
            
            while (true)
            {
                
                
                Console.WriteLine();
                var loggedUser = DataBase.GetCurrentUser().Id;
                Console.WriteLine(( "Binge Watching menu - user" , loggedUser));
                Console.WriteLine("---------------------------------------------------------------------");

                Console.Write("|  ");
                var allMenuStates = GetAllPossibleMenuStates();
                foreach (MenuState menuState in allMenuStates)
                {
                    Console.Write($"{Char.ToLower((char) menuState)} - {menuState}  |  ");
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var menuStateChoice = (MenuState) Enum.ToObject(typeof(MenuState), choice);
                if (allMenuStates.Contains(menuStateChoice))
                {
                    return menuStateChoice;
                }

                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        private MenuState[] GetAllPossibleMenuStates() =>
            (MenuState[]) Enum.GetValues(typeof(MenuState));
    }
}