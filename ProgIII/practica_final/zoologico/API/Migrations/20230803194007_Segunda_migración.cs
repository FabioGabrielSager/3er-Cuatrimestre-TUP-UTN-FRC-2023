using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Segunda_migración : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamiliaId",
                table: "animal",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_animal_FamiliaId",
                table: "animal",
                column: "FamiliaId");

            migrationBuilder.AddForeignKey(
                name: "FK_animal_familia_FamiliaId",
                table: "animal",
                column: "FamiliaId",
                principalTable: "familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animal_familia_FamiliaId",
                table: "animal");

            migrationBuilder.DropIndex(
                name: "IX_animal_FamiliaId",
                table: "animal");

            migrationBuilder.DropColumn(
                name: "FamiliaId",
                table: "animal");
        }
    }
}
