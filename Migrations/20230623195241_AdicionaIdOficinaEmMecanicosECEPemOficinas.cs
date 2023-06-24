using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revis.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaIdOficinaEmMecanicosECEPemOficinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mecanicos_Oficinas_oficinaid",
                table: "Mecanicos");

            migrationBuilder.RenameColumn(
                name: "oficinaid",
                table: "Mecanicos",
                newName: "oficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mecanicos_oficinaid",
                table: "Mecanicos",
                newName: "IX_Mecanicos_oficinaId");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "Oficinas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Mecanicos_Oficinas_oficinaId",
                table: "Mecanicos",
                column: "oficinaId",
                principalTable: "Oficinas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mecanicos_Oficinas_oficinaId",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "Oficinas");

            migrationBuilder.RenameColumn(
                name: "oficinaId",
                table: "Mecanicos",
                newName: "oficinaid");

            migrationBuilder.RenameIndex(
                name: "IX_Mecanicos_oficinaId",
                table: "Mecanicos",
                newName: "IX_Mecanicos_oficinaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Mecanicos_Oficinas_oficinaid",
                table: "Mecanicos",
                column: "oficinaid",
                principalTable: "Oficinas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
