using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revis.Migrations
{
    /// <inheritdoc />
    public partial class TentandoBotarLogin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true,
                oldNullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true,
                oldType: "nvarchar(100)",
                oldNullable: false,
                oldDefaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
