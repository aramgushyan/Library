using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrimaryKeysName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_IdAuthor",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_IdBook",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Books_IdBook",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Genres_IdGenre",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Instances_IdInstance",
                table: "BookLendings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Readers_IdReader",
                table: "BookLendings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Libraries_IdLibrary",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Instances_Books_IdBook",
                table: "Instances");

            migrationBuilder.DropForeignKey(
                name: "FK_Instances_Libraries_IdLibrary",
                table: "Instances");

            migrationBuilder.RenameColumn(
                name: "IdLibrary",
                table: "Instances",
                newName: "LibraryId");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Instances",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_IdLibrary",
                table: "Instances",
                newName: "IX_Instances_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_IdBook",
                table: "Instances",
                newName: "IX_Instances_BookId");

            migrationBuilder.RenameColumn(
                name: "IdLibrary",
                table: "Employees",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_IdLibrary",
                table: "Employees",
                newName: "IX_Employees_LibraryId");

            migrationBuilder.RenameColumn(
                name: "IdReader",
                table: "BookLendings",
                newName: "ReaderId");

            migrationBuilder.RenameColumn(
                name: "IdInstance",
                table: "BookLendings",
                newName: "InstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_IdReader",
                table: "BookLendings",
                newName: "IX_BookLendings_ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_IdInstance",
                table: "BookLendings",
                newName: "IX_BookLendings_InstanceId");

            migrationBuilder.RenameColumn(
                name: "IdGenre",
                table: "BookGenres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "BookGenres",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_IdGenre",
                table: "BookGenres",
                newName: "IX_BookGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_IdBook",
                table: "BookGenres",
                newName: "IX_BookGenres_BookId");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "AuthorBooks",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "AuthorBooks",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_IdBook",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_IdAuthor",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Libraries",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "BookGenres",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AuthorBooks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Books_BookId",
                table: "BookGenres",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Genres_GenreId",
                table: "BookGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Instances_InstanceId",
                table: "BookLendings",
                column: "InstanceId",
                principalTable: "Instances",
                principalColumn: "IdInstance",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Readers_ReaderId",
                table: "BookLendings",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "IdReader",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Libraries_LibraryId",
                table: "Employees",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "IdLibrary",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Books_BookId",
                table: "Instances",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Libraries_LibraryId",
                table: "Instances",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "IdLibrary",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Books_BookId",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Genres_GenreId",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Instances_InstanceId",
                table: "BookLendings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookLendings_Readers_ReaderId",
                table: "BookLendings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Libraries_LibraryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Instances_Books_BookId",
                table: "Instances");

            migrationBuilder.DropForeignKey(
                name: "FK_Instances_Libraries_LibraryId",
                table: "Instances");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Instances",
                newName: "IdLibrary");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Instances",
                newName: "IdBook");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_LibraryId",
                table: "Instances",
                newName: "IX_Instances_IdLibrary");

            migrationBuilder.RenameIndex(
                name: "IX_Instances_BookId",
                table: "Instances",
                newName: "IX_Instances_IdBook");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Employees",
                newName: "IdLibrary");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LibraryId",
                table: "Employees",
                newName: "IX_Employees_IdLibrary");

            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "BookLendings",
                newName: "IdReader");

            migrationBuilder.RenameColumn(
                name: "InstanceId",
                table: "BookLendings",
                newName: "IdInstance");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_ReaderId",
                table: "BookLendings",
                newName: "IX_BookLendings_IdReader");

            migrationBuilder.RenameIndex(
                name: "IX_BookLendings_InstanceId",
                table: "BookLendings",
                newName: "IX_BookLendings_IdInstance");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "BookGenres",
                newName: "IdGenre");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookGenres",
                newName: "IdBook");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                newName: "IX_BookGenres_IdGenre");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_BookId",
                table: "BookGenres",
                newName: "IX_BookGenres_IdBook");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "AuthorBooks",
                newName: "IdBook");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "AuthorBooks",
                newName: "IdAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_IdBook");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_IdAuthor");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Libraries",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "BookGenres",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Authors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "AuthorBooks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_IdAuthor",
                table: "AuthorBooks",
                column: "IdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_IdBook",
                table: "AuthorBooks",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Books_IdBook",
                table: "BookGenres",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Genres_IdGenre",
                table: "BookGenres",
                column: "IdGenre",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Instances_IdInstance",
                table: "BookLendings",
                column: "IdInstance",
                principalTable: "Instances",
                principalColumn: "IdInstance",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLendings_Readers_IdReader",
                table: "BookLendings",
                column: "IdReader",
                principalTable: "Readers",
                principalColumn: "IdReader",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Libraries_IdLibrary",
                table: "Employees",
                column: "IdLibrary",
                principalTable: "Libraries",
                principalColumn: "IdLibrary",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Books_IdBook",
                table: "Instances",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Libraries_IdLibrary",
                table: "Instances",
                column: "IdLibrary",
                principalTable: "Libraries",
                principalColumn: "IdLibrary",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
