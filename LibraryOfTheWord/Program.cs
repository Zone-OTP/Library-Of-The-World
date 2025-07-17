using LibraryOfTheWorld.DBData;
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

            //var serviceProvider = new ServiceCollection()
            //    .AddDbContext<LibraryContext>(options =>
            //        options.UseSqlServer("Server=DESKTOP-LTO7H71;Database=LIbraryDb;Trusted_Connection=True;"))
            //    .BuildServiceProvider();

            Application.Run(new SignUp());

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var signUpForm = scope.ServiceProvider.GetRequiredService<SignUp>();
                Application.Run(signUpForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer("Server=DESKTOP-LTO7H71;Database=LIbraryDb;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<SignUp>();
            services.AddScoped<Signin>();
            services.AddScoped<AddBookForm>();
            services.AddScoped<EditBookForm>();
            services.AddScoped<LibraryForAdmins>();
            services.AddScoped<LibraryForCustomers>();

            //services.AddScoped<IuserDataHandlerJson, DataHandler>();

        }
    }
}
