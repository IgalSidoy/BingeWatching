using System;
using BingeWatching.DataAccess;

namespace BingeWatching.Menus
{
    public static class Helpers
    {
        public static void LoginSubMenu()
        {
            Console.WriteLine("Enter your ID:");
            var userId = Console.ReadLine();
            DataBase.SwitchOrCreate(userId);
            Console.WriteLine();
        }
    }
}