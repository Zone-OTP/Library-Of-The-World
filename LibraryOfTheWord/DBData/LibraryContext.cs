using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Users;


namespace LibraryOfTheWorld.DBData
{
    public class LibraryContext : DbContext
    {
        public DbSet<JsonData> BooksJson { get; set; }
        public DbSet<JsonData> AuthorsJson { get; set; }
        public DbSet<JsonData> CustomersJson { get; set; }
        public DbSet<JsonData> AdminsJson { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}
