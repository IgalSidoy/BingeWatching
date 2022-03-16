using System.Collections.Generic;

namespace BingeWatching.DataAccess
{
    public static class DataBase
    {
        private static Entities.User CurrentUser { get; set; }
        
        private static readonly Dictionary<string ,Entities.User> Users= new Dictionary<string, Entities.User>();


        public static void SwitchOrCreate(string id)
        {
            if (Users.ContainsKey(id))
            {
                CurrentUser =Users[id];
            }
            else
            {
                CurrentUser = new Entities.User(id);;
                Users.Add(id,CurrentUser);
            }
        }

        public static Entities.User GetCurrentUser()
        {
            return CurrentUser;
        }

        public static bool AddFollower(string currentUserId,string userToFollowId)
        {

            if (!Users.ContainsKey(userToFollowId))
                return false;

            if (!Users[userToFollowId].Followers.ContainsKey(currentUserId))
            {
                Users[userToFollowId].Followers.Add(currentUserId, Users[currentUserId]);
                Users[currentUserId].Following.Add(userToFollowId, Users[userToFollowId]);
            }

            return true;
        }
        public static bool RemovedFollower(string currentUserId, string userToFollowId)
        {

            if (!Users.ContainsKey(userToFollowId))
                return false;

            if (Users[userToFollowId].Followers.ContainsKey(currentUserId))
            {
                Users[userToFollowId].Followers.Remove(currentUserId);
                Users[currentUserId].Following.Remove(userToFollowId);
            }
                return true;
        }
            
    }
}