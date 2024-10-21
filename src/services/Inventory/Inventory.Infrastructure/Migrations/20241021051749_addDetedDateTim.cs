using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDetedDateTim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditionDate",
                table: "Stuffs",
                newName: "EditionDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Stuffs",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "EditionDate",
                table: "Categories",
                newName: "EditionDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Categories",
                newName: "DeletedDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Stuffs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Stuffs");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "EditionDateTime",
                table: "Stuffs",
                newName: "EditionDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Stuffs",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "EditionDateTime",
                table: "Categories",
                newName: "EditionDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Categories",
                newName: "CreationDate");
        }
    }
}
