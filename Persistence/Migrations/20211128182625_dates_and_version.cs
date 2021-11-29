using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class dates_and_version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ChangingDate",
                table: "Persons",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Persons",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ChangingDate",
                table: "Genres",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Genres",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

       
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ChangingDate",
                table: "Books",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Books",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));


            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ChangingDate",
                table: "Authors",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Authors",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangingDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ChangingDate",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ChangingDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ChangingDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Authors");
        }
    }
}
