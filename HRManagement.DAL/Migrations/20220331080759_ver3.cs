using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "Department", "Salary", "StartDate", "Title" },
                values: new object[] { new DateTime(2022, 3, 31, 11, 7, 58, 487, DateTimeKind.Local).AddTicks(2142), "Teknoloji", 10000.0, new DateTime(2022, 3, 31, 11, 7, 58, 489, DateTimeKind.Local).AddTicks(2510), "Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "Department", "Salary", "StartDate", "Title" },
                values: new object[] { new DateTime(2022, 3, 30, 23, 50, 8, 134, DateTimeKind.Local).AddTicks(9865), null, 0.0, new DateTime(2022, 3, 30, 23, 50, 8, 136, DateTimeKind.Local).AddTicks(2170), null });
        }
    }
}
