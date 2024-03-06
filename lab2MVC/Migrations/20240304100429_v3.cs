using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2MVC.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "crsResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "degree",
                value: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "crsResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "degree",
                value: 90);
        }
    }
}
