using LibraryOfTheWorld.Classes;
using Microsoft.EntityFrameworkCore;


namespace LibraryOfTheWorld.DBData
{
    public class LibraryContext : DbContext
    {
        //public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = typeof(Book).Assembly.GetTypes()
            .Where(t => t.Namespace == "LibraryOfTheWorld.Classes" && !t.IsAbstract && !t.IsInterface);

            foreach (var type in entityTypes)
            {
                string keyName = $"{type.Name}Id";
                var keyProperty = type.GetProperty(keyName);

                if (keyProperty == null)
                {
                    keyName = "Id";
                    keyProperty = type.GetProperty(keyName);
                }

                if (keyProperty != null)
                {
                    var entity = modelBuilder.Entity(type);
                    entity.ToTable(type.Name + "s");
                    entity.HasKey(keyName);
                }
                else
                {
                    Console.WriteLine($"Skipping type {type.Name}: No key property ({type.Name}Id or Id) found.");
                }
            }
            modelBuilder.Entity<BookCheckout>()
        .HasOne(bc => bc.Customer)
        .WithMany(c => c.BookCheckouts)
        .HasForeignKey(bc => bc.CustomerId);

            modelBuilder.Entity<BookCheckout>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCheckouts)
                .HasForeignKey(bc => bc.BookId);
        }


    }
}
