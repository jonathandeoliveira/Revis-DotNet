using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revis.Migrations
{
    /// <inheritdoc />
    public partial class TentandoBotarLogin3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "orderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldNullable: false);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
