using Microsoft.EntityFrameworkCore.Migrations;

namespace JobFair.Data.Migrations
{
    public partial class alltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Register",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiringDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vacancies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Package = table.Column<int>(type: "int", nullable: false),
                    ApplyLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Cid);
                    table.ForeignKey(
                        name: "FK_Company_Register_Rid",
                        column: x => x.Rid,
                        principalTable: "Register",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Seeker",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeekerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeker", x => x.Sid);
                    table.ForeignKey(
                        name: "FK_Seeker_Register_Rid",
                        column: x => x.Rid,
                        principalTable: "Register",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InterestedCandidate",
                columns: table => new
                {
                    Icid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    Sid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedCandidate", x => x.Icid);
                    table.ForeignKey(
                        name: "FK_InterestedCandidate_Company_Cid",
                        column: x => x.Cid,
                        principalTable: "Company",
                        principalColumn: "Cid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestedCandidate_Seeker_Sid",
                        column: x => x.Sid,
                        principalTable: "Seeker",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SelectedCandidate",
                columns: table => new
                {
                    Scid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    Sid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCandidate", x => x.Scid);
                    table.ForeignKey(
                        name: "FK_SelectedCandidate_Company_Cid",
                        column: x => x.Cid,
                        principalTable: "Company",
                        principalColumn: "Cid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedCandidate_Seeker_Sid",
                        column: x => x.Sid,
                        principalTable: "Seeker",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Rid",
                table: "Company",
                column: "Rid");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedCandidate_Cid",
                table: "InterestedCandidate",
                column: "Cid");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedCandidate_Sid",
                table: "InterestedCandidate",
                column: "Sid");

            migrationBuilder.CreateIndex(
                name: "IX_Seeker_Rid",
                table: "Seeker",
                column: "Rid");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCandidate_Cid",
                table: "SelectedCandidate",
                column: "Cid");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCandidate_Sid",
                table: "SelectedCandidate",
                column: "Sid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestedCandidate");

            migrationBuilder.DropTable(
                name: "SelectedCandidate");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Seeker");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Register");
        }
    }
}
