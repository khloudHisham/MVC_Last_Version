using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2MVC.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURl",
                value: "man3.jpg");

            migrationBuilder.UpdateData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURl",
                value: "girl5.jpg");

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageURl", "Name" },
                values: new object[] { "man4.jpg", "Tamer" });

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageURl", "Name" },
                values: new object[] { "girl2.jpg", "Jasmen" });

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURl",
                value: "girl4.jpg");

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "ImageURl" },
                values: new object[] { "Koria", "girl3.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURl",
                value: "man2.jpg");

            migrationBuilder.UpdateData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURl",
                value: "girl2.jpg");

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageURl", "Name" },
                values: new object[] { "man2.jpg", "Ahmed" });

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageURl", "Name" },
                values: new object[] { "girl1.jpg", "Wafaa" });

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURl",
                value: "girl2.jpg");

            migrationBuilder.UpdateData(
                table: "instructor",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "ImageURl" },
                values: new object[] { "MNF", "girl1.jpg" });
        }
    }
}
