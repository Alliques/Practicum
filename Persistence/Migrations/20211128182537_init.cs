using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Authors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Authors", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Genres",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Genres", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Persons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Persons", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AuthorId = table.Column<int>(type: "int", nullable: false),
            //        WriteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Authors_AuthorId",
            //            column: x => x.AuthorId,
            //            principalTable: "Authors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BookGenre",
            //    columns: table => new
            //    {
            //        BooksId = table.Column<int>(type: "int", nullable: false),
            //        GenresId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
            //        table.ForeignKey(
            //            name: "FK_BookGenre_Books_BooksId",
            //            column: x => x.BooksId,
            //            principalTable: "Books",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BookGenre_Genres_GenresId",
            //            column: x => x.GenresId,
            //            principalTable: "Genres",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LibraryCards",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BooksId = table.Column<int>(type: "int", nullable: false),
            //        PersonsId = table.Column<int>(type: "int", nullable: false),
            //        ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LibraryCards", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LibraryCards_BooksId",
            //            column: x => x.BooksId,
            //            principalTable: "Books",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_LibraryCards_PersonsId",
            //            column: x => x.PersonsId,
            //            principalTable: "Persons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookGenre_GenresId",
            //    table: "BookGenre",
            //    column: "GenresId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Books_AuthorId",
            //    table: "Books",
            //    column: "AuthorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LibraryCards_BooksId",
            //    table: "LibraryCards",
            //    column: "BooksId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LibraryCards_PersonsId",
            //    table: "LibraryCards",
            //    column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
