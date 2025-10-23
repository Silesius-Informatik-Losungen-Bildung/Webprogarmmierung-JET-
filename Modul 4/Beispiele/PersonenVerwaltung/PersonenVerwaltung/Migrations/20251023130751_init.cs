using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonenVerwaltung.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Standorte",
                columns: table => new
                {
                    StandortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standorte", x => x.StandortId);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Alter = table.Column<int>(type: "int", nullable: true),
                    StandortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Personen_Standorte_StandortId",
                        column: x => x.StandortId,
                        principalTable: "Standorte",
                        principalColumn: "StandortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personen_StandortId",
                table: "Personen",
                column: "StandortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personen");

            migrationBuilder.DropTable(
                name: "Standorte");
        }
    }
}
