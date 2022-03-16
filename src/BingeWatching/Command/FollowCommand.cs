using BingeWatching.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using BingeWatching.DataAccess;

namespace BingeWatching.Command
{
    public class FollowCommand
    {
        public static void Execute(FollowerOptions type)
        {

            var currentUser = DataBase.GetCurrentUser();

            if (type == FollowerOptions.Follow)
            {
                Console.WriteLine("enter user ID to follow: ");

                var userToFollowId = Console.ReadLine();
                if (currentUser.Id == userToFollowId)
                    Console.WriteLine("can't follow yourself.");
                else
                {
                    if (!DataBase.AddFollower(currentUser.Id, userToFollowId))
                        Console.WriteLine("failed - user " + userToFollowId + " not found.");
                    else
                        Console.WriteLine("success.");
                }
            }
            if (type == FollowerOptions.Unfollow)
            {

                Console.WriteLine("enter user ID to unfollow: "); 

                var userToUnFollowId = Console.ReadLine();
                if (currentUser.Id == userToUnFollowId)
                    Console.WriteLine("can't unfollow yourself.");
                else
                {
                    if (!DataBase.RemovedFollower(currentUser.Id, userToUnFollowId))
                        Console.WriteLine("failed - user " + userToUnFollowId + " not found.");

                    else
                        Console.WriteLine("success.");
                }
            }
            if (type == FollowerOptions.PrintFollowers)
            {
                Console.WriteLine("");
               Console.WriteLine("List Of Followers: ");
                Console.WriteLine("-----------------------------");

                foreach(var follower in currentUser.Followers)
                {
                    Console.WriteLine("user - " + follower.Value.Id);
                }

            }
        }
    }
}
