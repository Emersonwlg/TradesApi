using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trades.Infrastructure.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ClientSector = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Symbol = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeCategory_Value_ClientSector",
                table: "TradeCategory",
                columns: new[] { "Value", "ClientSector" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeCategory");
        }
    }
}
