using System;
using System.Collections.Generic;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCheckout> BookCheckouts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LTO7H71;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.AuthorId, "IX_Books_AuthorId");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        modelBuilder.Entity<BookCheckout>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_BookCheckouts_BookId");

            entity.HasIndex(e => e.CustomerId, "IX_BookCheckouts_CustomerId");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCheckouts).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Customer).WithMany(p => p.BookCheckouts).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Email).HasDefaultValue("");
            entity.Property(e => e.PersonalGovermentId).HasColumnName("PersonalGovermentID");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_PasswordResets_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.PasswordResets).HasForeignKey(d => d.CustomerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
