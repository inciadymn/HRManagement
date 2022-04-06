using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class UpdateHasDataEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate", "Title" },
                values: new object[] { new DateTime(2022, 4, 6, 18, 26, 40, 636, DateTimeKind.Local).AddTicks(5064), new DateTime(2022, 4, 6, 18, 26, 40, 637, DateTimeKind.Local).AddTicks(7184), "Yazılım Uzmanı" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate", "Title" },
                values: new object[] { new DateTime(2022, 3, 31, 11, 8, 42, 177, DateTimeKind.Local).AddTicks(1541), new DateTime(2022, 3, 31, 11, 8, 42, 178, DateTimeKind.Local).AddTicks(5624), "Developer" });
        }
    }
}
