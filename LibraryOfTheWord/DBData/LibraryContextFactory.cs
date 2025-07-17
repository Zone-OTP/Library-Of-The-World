using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryOfTheWorld.DBData
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-LTO7H71;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
