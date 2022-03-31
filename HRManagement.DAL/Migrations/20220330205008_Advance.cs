using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class Advance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvanceType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PermitStatus = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advances_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 30, 23, 50, 8, 134, DateTimeKind.Local).AddTicks(9865), new DateTime(2022, 3, 30, 23, 50, 8, 136, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.CreateIndex(
                name: "IX_Advances_EmployeeID",
                table: "Advances",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advances");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 29, 22, 0, 21, 94, DateTimeKind.Local).AddTicks(1591), new DateTime(2022, 3, 29, 22, 0, 21, 95, DateTimeKind.Local).AddTicks(7145) });
        }
    }
}
