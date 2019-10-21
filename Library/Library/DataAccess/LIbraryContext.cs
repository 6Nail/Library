using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library
{
    public class LIbraryContext : DbContext
    {
        public class LibraryContext : DbContext
        {
            public LibraryContext()
            {
                Database.EnsureCreated();
            }

            public DbSet<Student> Stu { get; set; }
            public DbSet<Book> Books { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=A-305-08;Database=Library;Trusted_connection=true");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<BookStudent>().HasOne(x => x.Student).WithMany(x => x.Books);
                modelBuilder.Entity<BookStudent>().HasOne(x => x.Book).WithMany(x => x.Students);
                modelBuilder.Entity<Book>().ToTable("_books");
                modelBuilder.Entity<Student>().ToTable("_students");
                modelBuilder.Entity<BookStudent>().ToTable("_books_students");

                modelBuilder.Entity<BookStudent>().Property("StudentId").HasColumnName("student_ID");
                modelBuilder.Entity<BookStudent>().Property("BookId").HasColumnName("book_ID");
                modelBuilder.Entity<BookStudent>().Property("CreationDate").HasColumnName("creation_date");
                modelBuilder.Entity<BookStudent>().Property("DeletedDate").HasColumnName("deleted_date");


                modelBuilder.Entity<Student>().Property("Id").HasColumnName("student_ID");
                modelBuilder.Entity<Student>().Property("CreationDate").HasColumnName("creation_date");
                modelBuilder.Entity<Student>().Property("DeletedDate").HasColumnName("deleted_date");
                modelBuilder.Entity<Student>().Property("FullName").HasColumnName("full_name");



                modelBuilder.Entity<Book>().Property("Id").HasColumnName("book_ID");
                modelBuilder.Entity<Book>().Property("CreationDate").HasColumnName("creation_date");
                modelBuilder.Entity<Book>().Property("DeletedDate").HasColumnName("deleted_date");
                modelBuilder.Entity<Book>().Property("TitleName").HasColumnName("title_name");
            }

        }
    }
}
