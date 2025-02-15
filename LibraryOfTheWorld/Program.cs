using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.Users;
using System.Xml.Linq;
using LibraryOfTheWorld;

namespace LibraryOfTheWorld
{
    internal static class Program
    {
        /// <summary>
        ///
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {


            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignUp());

        }

    }
}
