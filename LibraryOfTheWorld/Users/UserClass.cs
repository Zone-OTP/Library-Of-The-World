using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Users
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        internal static JsonUsersDataHandler datahandler = new JsonUsersDataHandler();
        private static List<User> UserList { get; set; } = new List<User>();

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public void addUser(User user)
        {
            UserList = datahandler.LoadUsersJson();
            UserList.Add(user);
            datahandler.SaveUserJson(UserList);
        }

        public void showUsers() {
            foreach (var user in UserList) { Console.WriteLine($"{user.Name} + {user.Password}"); };
        }
    }

}
