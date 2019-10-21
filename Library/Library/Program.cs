using Library.Models;
using System;
using System.Linq;
using static Library.LIbraryContext;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                Student student = new Student
                {
                    FullName = "Abay Pushkin"
                };

                Book book = new Book
                {
                    TitleName = "Над пропастью поржи",
                };

                context.Add(book);
                context.Add(student);
                context.Add(new BookStudent
                {
                    Book = book,
                    Student = student,
                });

                context.SaveChanges();
                var result = context.Books.ToList();
            }
        }
    }
}
