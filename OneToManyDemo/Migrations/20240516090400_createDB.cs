using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurId);
                });

            migrationBuilder.CreateTable(
                name: "Boeks",
                columns: table => new
                {
                    BoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeks", x => x.BoekId);
                    table.ForeignKey(
                        name: "FK_Boeks_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurId");
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "AuteurId", "Naam" },
                values: new object[,]
                {
                    { 1, "Isabel Allende" },
                    { 2, "Stephen King" },
                    { 3, "J.K. Rowling" },
                    { 4, "G.Garcia Marquez" }
                });

            migrationBuilder.InsertData(
                table: "Boeks",
                columns: new[] { "BoekId", "AuteurId", "Titel" },
                values: new object[,]
                {
                    { 1, 1, "Eva Luna" },
                    { 2, 1, "La casa de los Espiritus" },
                    { 3, 2, "Horror book" },
                    { 4, 3, "Harry Potter 1" },
                    { 5, 4, "Goragora" },
                    { 6, 2, "Horror book2" },
                    { 7, 3, "Harry Potter and friends" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeks_AuteurId",
                table: "Boeks",
                column: "AuteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boeks");

            migrationBuilder.DropTable(
                name: "Auteurs");
        }
    }
}
