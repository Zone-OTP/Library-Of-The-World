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
        void SaveDataJson<T>(List<T> data,string fileName);
        List<T> LoadDataJson<T>(string fileName);
    }
}

