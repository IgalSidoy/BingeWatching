using System;
using System.Threading.Tasks;

namespace BingeWatching.Menus
{
    public class SwitchUserMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.SwitchUser;
        }

        public void Handle()
        {
            Helpers.LoginSubMenu();
        }

    }
}