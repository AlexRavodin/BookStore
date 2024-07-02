﻿// <auto-generated />
using System;
using BookStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookStore.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 4
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 5
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 5
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 4
                        });
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            BookId = 2,
                            GenreId = 1
                        },
                        new
                        {
                            BookId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            BookId = 3,
                            GenreId = 3
                        },
                        new
                        {
                            BookId = 4,
                            GenreId = 4
                        },
                        new
                        {
                            BookId = 5,
                            GenreId = 2
                        },
                        new
                        {
                            BookId = 6,
                            GenreId = 3
                        },
                        new
                        {
                            BookId = 7,
                            GenreId = 2
                        },
                        new
                        {
                            BookId = 8,
                            GenreId = 2
                        },
                        new
                        {
                            BookId = 9,
                            GenreId = 3
                        },
                        new
                        {
                            BookId = 10,
                            GenreId = 4
                        });
                });

            modelBuilder.Entity("BookStore.Api.Models.Books.Entity.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Leo",
                            LastName = "Tolstoy"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Fyodor",
                            LastName = "Dostoevsky"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Mikhail",
                            LastName = "Bulgakov"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Jane",
                            LastName = "Austen"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "J.R.R.",
                            LastName = "Tolkien"
                        });
                });

            modelBuilder.Entity("BookStore.Api.Models.Books.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("BookImageId")
                        .HasColumnType("uuid");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("QualityDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 0,
                            Name = "War and Peace",
                            Price = 150.0m,
                            QualityDescription = "Excellent",
                            Summary = "A historical novel that chronicles the tumultuous events in Russia during the Napoleonic Wars."
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 0,
                            Name = "Anna Karenina",
                            Price = 120.0m,
                            QualityDescription = "Very Good",
                            Summary = "A tragic story of love and infidelity in imperial Russia."
                        },
                        new
                        {
                            Id = 3,
                            BookImageId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            GenreId = 0,
                            Name = "The Master and Margarita",
                            Price = 130.0m,
                            QualityDescription = "Good",
                            Summary = "A fantastical story set in Soviet Russia that explores themes of good and evil."
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 0,
                            Name = "Pride and Prejudice",
                            Price = 140.0m,
                            QualityDescription = "Excellent",
                            Summary = "A romantic novel that explores the complexities of relationships in 19th-century England."
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 0,
                            Name = "Crime and Punishment",
                            Price = 110.0m,
                            QualityDescription = "Very Good",
                            Summary = "A psychological novel that delves into the mind of a young man who commits a heinous crime."
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 0,
                            Name = "The Lord of the Rings",
                            Price = 160.0m,
                            QualityDescription = "Good",
                            Summary = "A high fantasy novel that follows the quest to destroy the One Ring."
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 0,
                            Name = "The Count of Monte Cristo",
                            Price = 130.0m,
                            QualityDescription = "Excellent",
                            Summary = "An adventure novel that follows the story of betrayal, revenge, and redemption."
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 0,
                            Name = "The Picture of Dorian Gray",
                            Price = 120.0m,
                            QualityDescription = "Very Good",
                            Summary = "A philosophical novel that explores the themes of beauty, morality, and the supernatural."
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 0,
                            Name = "The Hobbit",
                            Price = 150.0m,
                            QualityDescription = "Good",
                            Summary = "A fantasy novel that follows the journey of Bilbo Baggins to reclaim the Lonely Mountain."
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 0,
                            Name = "Wuthering Heights",
                            Price = 140.0m,
                            QualityDescription = "Excellent",
                            Summary = "A romantic novel that explores the complex and often destructive nature of love."
                        });
                });

            modelBuilder.Entity("BookStore.Api.Models.Carts.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookStore.Api.Models.Carts.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookStore.Api.Models.Genres.Entity.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A genre of literature that reconstructs historical events.",
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A book accepted as being exemplary or noteworthy.",
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A genre of speculative fiction set in a fictional universe.",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A genre of literature that focuses on the romantic relationship between characters.",
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("BookStore.Api.Models.Images.Entity.BookImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookImages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            BookId = 3,
                            Extension = ".webp"
                        });
                });

            modelBuilder.Entity("BookStore.Api.Models.Images.Entity.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UserImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.HasOne("BookStore.Api.Models.Books.Entity.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Api.Models.Books.Entity.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("BookStore.Api.Models.Books.Entity.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Api.Models.Genres.Entity.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.Api.Models.Carts.Entity.CartItem", b =>
                {
                    b.HasOne("BookStore.Api.Models.Books.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Api.Models.Carts.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("BookStore.Api.Models.Images.Entity.BookImage", b =>
                {
                    b.HasOne("BookStore.Api.Models.Books.Entity.Book", "Book")
                        .WithOne("BookImage")
                        .HasForeignKey("BookStore.Api.Models.Images.Entity.BookImage", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.Api.Models.Books.Entity.Book", b =>
                {
                    b.Navigation("BookImage");
                });

            modelBuilder.Entity("BookStore.Api.Models.Carts.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
