using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp.Api.Models;

namespace TestApp.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) :
    IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Book> Books { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(
            new Genre
            {
                Id = 1, Name = "Historical Fiction", Description = "A genre of literature that reconstructs historical events." 
            },
            new Genre
            {
                Id = 2, Name = "Classic", Description = "A book accepted as being exemplary or noteworthy." 
            },
            new Genre
            {
                Id = 3, Name = "Fantasy", Description = "A genre of speculative fiction set in a fictional universe." 
            },
            new Genre
            {
                Id = 4, Name = "Romance", Description = "A genre of literature that focuses on the romantic relationship between characters."
            }
        );
        
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Name = "War and Peace",
                Summary = "A historical novel that chronicles the tumultuous events in Russia during the Napoleonic Wars.",
                Price = 150.0m,
                QualityDescription = "Excellent",
                GenreId = 1
            },
            new Book
            {
                Id = 2,
                Name = "Anna Karenina",
                Summary = "A tragic story of love and infidelity in imperial Russia.",
                Price = 120.0m,
                QualityDescription = "Very Good",
                GenreId = 2
            },
            new Book
            {
                Id = 3,
                Name = "The Master and Margarita",
                Summary = "A fantastical story set in Soviet Russia that explores themes of good and evil.",
                Price = 130.0m,
                QualityDescription = "Good",
                GenreId = 3
            },
            new Book
            {
                Id = 4,
                Name = "Pride and Prejudice",
                Summary = "A romantic novel that explores the complexities of relationships in 19th-century England.",
                Price = 140.0m,
                QualityDescription = "Excellent",
                GenreId = 4
            },
            new Book
            {
                Id = 5,
                Name = "Crime and Punishment",
                Summary = "A psychological novel that delves into the mind of a young man who commits a heinous crime.",
                Price = 110.0m,
                QualityDescription = "Very Good",
                GenreId = 2
            },
            new Book
            {
                Id = 6,
                Name = "The Lord of the Rings",
                Summary = "A high fantasy novel that follows the quest to destroy the One Ring.",
                Price = 160.0m,
                QualityDescription = "Good",
                GenreId = 3
            },
            new Book
            {
                Id = 7,
                Name = "The Count of Monte Cristo",
                Summary = "An adventure novel that follows the story of betrayal, revenge, and redemption.",
                Price = 130.0m,
                QualityDescription = "Excellent",
                GenreId = 1
            },
            new Book
            {
                Id = 8,
                Name = "The Picture of Dorian Gray",
                Summary = "A philosophical novel that explores the themes of beauty, morality, and the supernatural.",
                Price = 120.0m,
                QualityDescription = "Very Good",
                GenreId = 2
            },
            new Book
            {
                Id = 9,
                Name = "The Hobbit",
                Summary = "A fantasy novel that follows the journey of Bilbo Baggins to reclaim the Lonely Mountain.",
                Price = 150.0m,
                QualityDescription = "Good",
                GenreId = 3
            },
            new Book
            {
                Id = 10,
                Name = "Wuthering Heights",
                Summary = "A romantic novel that explores the complex and often destructive nature of love.",
                Price = 140.0m,
                QualityDescription = "Excellent",
                GenreId = 4
            }
        );
        
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                FirstName = "Leo",
                LastName = "Tolstoy"
            },
            new Author
            {
                Id = 2,
                FirstName = "Fyodor",
                LastName = "Dostoevsky"
            },
            new Author
            {
                Id = 3,
                FirstName = "Mikhail",
                LastName = "Bulgakov"
            }
        );
        
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookAuthor",
                j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                j =>
                {
                    j.HasKey("BookId", "AuthorId");
                    j.HasData(
                        new { BookId = 1, AuthorId = 1 },
                        new { BookId = 2, AuthorId = 1 },
                        new { BookId = 2, AuthorId = 2 },
                        new { BookId = 3, AuthorId = 3 },
                        new { BookId = 4, AuthorId = 4 },
                        new { BookId = 5, AuthorId = 2 },
                        new { BookId = 6, AuthorId = 5 },
                        new { BookId = 7, AuthorId = 1 },
                        new { BookId = 8, AuthorId = 2 },
                        new { BookId = 9, AuthorId = 5 },
                        new { BookId = 10, AuthorId = 4 }
                    );
                }
            );
    }
}
