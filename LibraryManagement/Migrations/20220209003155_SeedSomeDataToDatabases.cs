using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    public partial class SeedSomeDataToDatabases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1L, "Machado", "de Assis" },
                    { 2L, "Joanne", "Rowling" },
                    { 3L, "Clarice", "Lispector" }
                });

            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Romance" },
                    { 2L, "Science Fiction" },
                    { 3L, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "id", "author_id", "genre_id", "title" },
                values: new object[,]
                {
                    { 1L, 2L, 3L, "Harry Potter e a Pedra filosofal" },
                    { 2L, 1L, 2L, "O Alienista" },
                    { 3L, 3L, 1L, "A Hora da Estrela" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
