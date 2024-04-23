using Book;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Book
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Authors>(a =>
            {
                a.HasData(new Authors
                {
                    Id = 1,
                    FullName = "J.K. Rowling",
                    
                });
                a.HasData(new Authors
                {
                    Id = 2,
                    FullName = "Walter Isaacson",
                    
                });
            });

            _builder.Entity<Book>(b =>
            {
                b.HasData(new Book
                {
                    Id = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.",
                    IsRead = true,
                    DateRead = new DateTime (2024, 04, 23),
                    Rate = 1,
                    Genre = "horror",
                    CoverUrl = "file:///C:/Users/COMPUTER/Documents/Zalo%20Received%20Files/Web2-P1-2.pdf",
                    DateAdded = new DateTime(2023, 04, 23),
                });
                b.HasData(new Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. ",
                    IsRead = true,
                    DateRead = new DateTime(2024, 04, 24),
                    Rate = 1,
                    Genre = "horror",
                    CoverUrl = "file:///C:/Users/COMPUTER/Documents/Zalo%20Received%20Files/Web2-P1-2.pdf",
                    DateAdded = new DateTime(2023, 04, 24),
                });
                b.HasData(new Book
                {
                    Id = 3,
                    Title = "Steve Jobs",
                    Description = "Walter Isaacson’s “enthralling” (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs.",
                    IsRead = true,
                    DateRead = new DateTime(2024, 04, 25),
                    Rate = 1,
                    Genre = "horror",
                    CoverUrl = "file:///C:/Users/COMPUTER/Documents/Zalo%20Received%20Files/Web2-P1-2.pdf",
                    DateAdded = new DateTime(2023, 04, 25),
                });
            });
        }
    }
}