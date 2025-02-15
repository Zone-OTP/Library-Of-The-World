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
        public int Id { get; }
        public string Name { get; set; }
        public string Password { get; set; }
        internal static int _nextId = 1;

        internal static JsonUsersDataHandler datahandler = new JsonUsersDataHandler();
        private static List<User> UserList { get; set; } = new List<User>();

        public User(string name, string password)
        {
            Id = _nextId++;
            Name = name;
            Password = password;
        }
        public void AddUser(User user)
        {
            UserList = datahandler.LoadUsersJson();
            UserList.Add(user);
            datahandler.SaveUserJson(UserList);
        }

        public void ShowUsers() {
            UserList = datahandler.LoadUsersJson();
            foreach (var user in UserList) { Console.WriteLine($"{user.Id} + {user.Name} + {user.Password}"); };
        }

        public bool SignInCheck(string username, string password) {
            UserList = datahandler.LoadUsersJson();
            foreach (User user in UserList) {
                if (username.Trim() == user.Name && password.Trim() == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
