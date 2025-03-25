using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Classes;

namespace LibraryOfTheWorld.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JsonData> JsonData { get; set; } 

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<JsonData>()
                .Property(j => j.Content)
                .HasColumnType("nvarchar(max)");
        }
    }
}
