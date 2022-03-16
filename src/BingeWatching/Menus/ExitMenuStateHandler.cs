using System;
using System.Threading.Tasks;

namespace BingeWatching.Menus
{
    public class ExitMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Exit;
        }

        public void Handle()
        {
            Console.WriteLine("Au revoir, Shoshana!");
            Environment.Exit(0);
        }
    }
}