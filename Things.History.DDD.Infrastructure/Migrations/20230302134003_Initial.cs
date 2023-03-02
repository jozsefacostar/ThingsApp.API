using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Things.History.DDD.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamA = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: false),
                    TeamB = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: false),
                    GoalsA = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    GoalsB = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    DateInitial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finalized = table.Column<bool>(type: "bit", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
