using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Users;

namespace LibraryOfTheWorld.Services
{
    public class AdminService
    {
        private static List<Admin> adminList;
        private static JsonUsersDataHandler dataHandler;
        public static int _nextId = 1;

        static AdminService()
        {
            dataHandler = new JsonUsersDataHandler();
            adminList = dataHandler.LoadDataJson<Admin>("Admins");
        }

        public static void SaveAdmins()
        {
            dataHandler.SaveDataJson<Admin>(adminList, "Admins");
        }

        private static bool IsUsernameTaken(string username)
        {
            return adminList.Any(user => user.Name == username);
        }
        public static void AddUser(Admin user)
        {
            adminList = dataHandler.LoadDataJson<Admin>("Admins");
            if (IsUsernameTaken(user.Name))
            {
                MessageBox.Show("Name is taken, choose another Name");
                return;
            }
            adminList.Add(user);
            dataHandler.SaveDataJson(adminList, "Admins");
        }
        public static void ShowUsers()
        {
            adminList = dataHandler.LoadDataJson<Admin>("Admins");
            foreach (var user in adminList) { Console.WriteLine($"{user.AdminId} + {user.Name} + {user.Password}"); };
        }
        public static bool SignInCheck(string username, string password)
        {
            adminList = dataHandler.LoadDataJson<Admin>("Admins");
            foreach (Admin user in adminList)
            {
                if (username == user.Name && password.Trim() == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
