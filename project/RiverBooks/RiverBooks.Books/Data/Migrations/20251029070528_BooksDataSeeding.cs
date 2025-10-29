using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class BooksDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2dd04ba1-81b5-4a2b-b5d7-d9a8520628e1"), "Vaughn Vernon", 12.99m, "Implementing Domain-Driven Design" },
                    { new Guid("34125d61-9ae7-4dda-994b-d9623b3fbcff"), "Robert C. Martin", 10.99m, "Clean Architecture" },
                    { new Guid("66b37ca5-6445-4da8-bac2-4896b9273a8c"), "Eric Evans", 11.99m, "Domain-Driven Design" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2dd04ba1-81b5-4a2b-b5d7-d9a8520628e1"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("34125d61-9ae7-4dda-994b-d9623b3fbcff"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("66b37ca5-6445-4da8-bac2-4896b9273a8c"));
        }
    }
}
