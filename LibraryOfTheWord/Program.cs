using LibraryOfTheWorld.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
