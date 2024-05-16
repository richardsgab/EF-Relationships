using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class book8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boeks",
                columns: new[] { "BoekId", "AuteurId", "Titel" },
                values: new object[] { 8, 3, "Harry Potter and enemies" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8);
        }
    }
}
