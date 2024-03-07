using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Correction_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_barcos_socios_idBarco",
                table: "barcos");

            migrationBuilder.DropIndex(
                name: "IX_barcos_idBarco",
                table: "barcos");

            migrationBuilder.DropColumn(
                name: "idBarco",
                table: "barcos");

            migrationBuilder.RenameColumn(
                name: "IdSocio",
                table: "barcos",
                newName: "idSocio");

            migrationBuilder.CreateIndex(
                name: "IX_barcos_idSocio",
                table: "barcos",
                column: "idSocio");

            migrationBuilder.AddForeignKey(
                name: "FK_barcos_socios_idSocio",
                table: "barcos",
                column: "idSocio",
                principalTable: "socios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_barcos_socios_idSocio",
                table: "barcos");

            migrationBuilder.DropIndex(
                name: "IX_barcos_idSocio",
                table: "barcos");

            migrationBuilder.RenameColumn(
                name: "idSocio",
                table: "barcos",
                newName: "IdSocio");

            migrationBuilder.AddColumn<int>(
                name: "idBarco",
                table: "barcos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_barcos_idBarco",
                table: "barcos",
                column: "idBarco");

            migrationBuilder.AddForeignKey(
                name: "FK_barcos_socios_idBarco",
                table: "barcos",
                column: "idBarco",
                principalTable: "socios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
