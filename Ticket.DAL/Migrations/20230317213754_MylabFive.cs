using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab5.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MylabFive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicket",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicket", x => new { x.DevelopersId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Issues_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Asthma" },
                    { 4, "Depression" },
                    { 5, "Arthritis" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "john" },
                    { 2, "isaac" },
                    { 3, "doe" },
                    { 4, "pop" },
                    { 5, "ann" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DepartmentId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "good" },
                    { 2, 2, "bad" },
                    { 3, 1, "mideum" },
                    { 4, 3, "amazing" },
                    { 5, 4, "wow" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicket_PatientsId",
                table: "DeveloperTicket",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DepartmentId",
                table: "Patients",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTicket");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
