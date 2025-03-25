using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.Users;
using System.Xml.Linq;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

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
            var serviceProvider = new ServiceCollection()
                .AddDbContext<LibraryContext>(options =>
                    options.UseSqlServer("Server=DESKTOP-LTO7H71;Database=LIbraryDb;Trusted_Connection=True;"))
                .BuildServiceProvider();
            Application.Run(new SignUp());
            
            
        }

    }
}
