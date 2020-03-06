using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class ManyTOMAnyRelationsCorrectFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers_Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherIdFK = table.Column<int>(nullable: false),
                    CourseIdFK = table.Column<int>(nullable: false),
                    Hours = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_courses_CourseIdFK",
                        column: x => x.CourseIdFK,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_Teachers_TeacherIdFK",
                        column: x => x.TeacherIdFK,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Courses_CourseIdFK",
                table: "Teachers_Courses",
                column: "CourseIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Courses_TeacherIdFK",
                table: "Teachers_Courses",
                column: "TeacherIdFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers_Courses");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
