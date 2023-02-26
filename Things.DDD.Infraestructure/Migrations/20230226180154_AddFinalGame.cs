using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Things.DDD.Infrastructure.Migrations
{
    public partial class AddFinalGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateGame",
                table: "Games",
                newName: "DateInitial");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFinal",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFinal",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "DateInitial",
                table: "Games",
                newName: "DateGame");
        }
    }
}
