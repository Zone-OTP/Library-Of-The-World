using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Users
{
    public class Admin
    {
        public int AdminId { get; }
        public string Name { get; set; }
        public string Password { get; set; }
        private static int _nextId = 1;

        public Admin(string name, string password)
        {
            AdminId = _nextId++;
            Name = name;
            Password = password;
        }

        //private bool IsUsernameTaken(string username)
        //{
        //    return UserList.Any(user => user.Name == username);
        //}
        //public void AddUser(Admin user)
        //{
        //    UserList = datahandler.LoadDataJson<Admin>("Admins");
        //    if (IsUsernameTaken(user.Name))
        //    {
        //        MessageBox.Show("Name is taken, choose another Name");
        //        return;
        //    }
        //    UserList.Add(user);
        //    datahandler.SaveDataJson(UserList, "Admins");
        //}
        //public void ShowUsers() {
        //    UserList = datahandler.LoadDataJson<Admin>("Admins");
        //    foreach (var user in UserList) { Console.WriteLine($"{user.Id} + {user.Name} + {user.Password}"); };
        //}
        //public bool SignInCheck(string username, string password) {
        //    UserList = datahandler.LoadDataJson<Admin>("Admins");
        //    foreach (Admin user in UserList) {
        //        if (username == user.Name && password.Trim() == user.Password)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
