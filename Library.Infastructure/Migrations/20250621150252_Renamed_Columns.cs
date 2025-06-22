using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdReader",
                table: "Readers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdLibrary",
                table: "Libraries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdInstance",
                table: "Instances",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdGenre",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdEmployee",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdBookLending",
                table: "BookLendings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdBookGenre",
                table: "BookGenres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Authors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAuthorBook",
                table: "AuthorBooks",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Readers",
                newName: "IdReader");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Libraries",
                newName: "IdLibrary");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instances",
                newName: "IdInstance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "IdGenre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "IdEmployee");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "IdBook");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookLendings",
                newName: "IdBookLending");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookGenres",
                newName: "IdBookGenre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "IdAuthor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AuthorBooks",
                newName: "IdAuthorBook");
        }
    }
}
