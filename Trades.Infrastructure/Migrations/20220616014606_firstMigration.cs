using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trades.Infrastructure.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trade-category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ClientSector = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trade-category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trade-category_Value_ClientSector",
                table: "trade-category",
                columns: new[] { "Value", "ClientSector" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trade-category");
        }
    }
}
