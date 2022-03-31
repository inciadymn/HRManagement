using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class employeSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "Department", "Salary", "StartDate", "Title" },
                values: new object[] { new DateTime(2022, 3, 31, 11, 8, 42, 177, DateTimeKind.Local).AddTicks(1541), "Teknoloji", 10000.0, new DateTime(2022, 3, 31, 11, 8, 42, 178, DateTimeKind.Local).AddTicks(5624), "Developer" });
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
