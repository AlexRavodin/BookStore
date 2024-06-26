using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Leo", "Tolstoy" },
                    { 2, "Fyodor", "Dostoevsky" },
                    { 3, "Mikhail", "Bulgakov" },
                    { 4, "Jane", "Austen" },
                    { 5, "J.R.R.", "Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A genre of literature that reconstructs historical events.", "Historical Fiction" },
                    { 2, "A book accepted as being exemplary or noteworthy.", "Classic" },
                    { 3, "A genre of speculative fiction set in a fictional universe.", "Fantasy" },
                    { 4, "A genre of literature that focuses on the romantic relationship between characters.", "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "GenreId", "Name", "Price", "QualityDescription", "Summary" },
                values: new object[,]
                {
                    { 1, 1, "War and Peace", 150.0m, "Excellent", "A historical novel that chronicles the tumultuous events in Russia during the Napoleonic Wars." },
                    { 2, 2, "Anna Karenina", 120.0m, "Very Good", "A tragic story of love and infidelity in imperial Russia." },
                    { 3, 3, "The Master and Margarita", 130.0m, "Good", "A fantastical story set in Soviet Russia that explores themes of good and evil." },
                    { 4, 4, "Pride and Prejudice", 140.0m, "Excellent", "A romantic novel that explores the complexities of relationships in 19th-century England." },
                    { 5, 2, "Crime and Punishment", 110.0m, "Very Good", "A psychological novel that delves into the mind of a young man who commits a heinous crime." },
                    { 6, 3, "The Lord of the Rings", 160.0m, "Good", "A high fantasy novel that follows the quest to destroy the One Ring." },
                    { 7, 1, "The Count of Monte Cristo", 130.0m, "Excellent", "An adventure novel that follows the story of betrayal, revenge, and redemption." },
                    { 8, 2, "The Picture of Dorian Gray", 120.0m, "Very Good", "A philosophical novel that explores the themes of beauty, morality, and the supernatural." },
                    { 9, 3, "The Hobbit", 150.0m, "Good", "A fantasy novel that follows the journey of Bilbo Baggins to reclaim the Lonely Mountain." },
                    { 10, 4, "Wuthering Heights", 140.0m, "Excellent", "A romantic novel that explores the complex and often destructive nature of love." }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 2, 5 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 8 },
                    { 5, 9 },
                    { 4, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    BooksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");
        }
    }
}
