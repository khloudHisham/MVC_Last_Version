using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab2MVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instructor_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_instructor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "crsResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crsResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_crsResult_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_crsResult_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Mazen", "CS" },
                    { 2, "Ali", "AI" },
                    { 3, "Noha", "IS" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Degree", "DepartmentId", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 100, 1, 60, "C#" },
                    { 2, 100, 3, 60, "GIS" },
                    { 3, 100, 2, 60, "ML" }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentId", "ImageURl", "Name", "grade" },
                values: new object[,]
                {
                    { 1, "Tanan", 1, "man2.jpg", "Ahmed", 4 },
                    { 2, "NewYourk", 2, "girl1.jpg", "Hager", 5 },
                    { 3, "Turkia", 3, "girl2.jpg", "Soha", 6 }
                });

            migrationBuilder.InsertData(
                table: "crsResult",
                columns: new[] { "Id", "CourseId", "TraineeId", "degree" },
                values: new object[,]
                {
                    { 1, 1, 1, 80 },
                    { 2, 2, 2, 90 },
                    { 3, 3, 3, 100 }
                });

            migrationBuilder.InsertData(
                table: "instructor",
                columns: new[] { "Id", "Address", "CourseId", "DepartmentId", "ImageURl", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 1, "man2.jpg", "Ahmed", 15000 },
                    { 2, "Giza", 3, 2, "girl1.jpg", "Wafaa", 20000 },
                    { 3, "Alex", 2, 1, "girl2.jpg", "Sama", 4000 },
                    { 4, "MNF", 1, 3, "girl1.jpg", "Maha", 8000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_crsResult_CourseId",
                table: "crsResult",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_crsResult_TraineeId",
                table: "crsResult",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_CourseId",
                table: "instructor",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_DepartmentId",
                table: "instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DepartmentId",
                table: "Trainee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crsResult");

            migrationBuilder.DropTable(
                name: "instructor");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
