using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ap12Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hersteller",
                columns: table => new
                {
                    HerstellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EingefügtAm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hersteller", x => x.HerstellerId);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Preis = table.Column<double>(type: "float", nullable: false),
                    EingefügtAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HerstellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkte_Hersteller_HerstellerId",
                        column: x => x.HerstellerId,
                        principalTable: "Hersteller",
                        principalColumn: "HerstellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_HerstellerId",
                table: "Produkte",
                column: "HerstellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Hersteller");
        }
    }
}
