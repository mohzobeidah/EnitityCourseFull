using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class kkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    StudentAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    city = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    StudentIdPK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_students_StudentIdPK",
                        column: x => x.StudentIdPK,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StudentIdPK",
                table: "StudentAddresses",
                column: "StudentIdPK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
