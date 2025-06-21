using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoReference.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobDuties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDuties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuilderJobDuties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuilderId = table.Column<int>(type: "int", nullable: false),
                    JobDutiesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuilderJobDuties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuilderJobDuties_Builders_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "Builders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuilderJobDuties_JobDuties_JobDutiesId",
                        column: x => x.JobDutiesId,
                        principalTable: "JobDuties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuilderJobDuties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Builders",
                columns: new[] { "Id", "FirstName", "Patronymic", "SecondName" },
                values: new object[] { 1, "Jhon", "Jhonson", "Jhons" });

            migrationBuilder.InsertData(
                table: "JobDuties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "job 1 desc", "job 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin", "1", 1 });

            migrationBuilder.InsertData(
                table: "BuilderJobDuties",
                columns: new[] { "Id", "BuilderId", "JobDutiesId", "UserId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BuilderJobDuties_BuilderId",
                table: "BuilderJobDuties",
                column: "BuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderJobDuties_JobDutiesId",
                table: "BuilderJobDuties",
                column: "JobDutiesId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderJobDuties_UserId",
                table: "BuilderJobDuties",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuilderJobDuties");

            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "JobDuties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
