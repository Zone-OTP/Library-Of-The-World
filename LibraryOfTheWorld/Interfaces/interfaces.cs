using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfTheWorld.Users;

namespace LibraryOfTheWorld.Interfaces
{
    public interface IuserDataHandlerJson
    {
        void SaveUserJson(List<User> users);
        List<User> LoadUsersJson();
    }
}

