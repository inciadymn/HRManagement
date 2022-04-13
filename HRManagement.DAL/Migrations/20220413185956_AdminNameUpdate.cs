using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class AdminNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 4, 13, 21, 59, 56, 323, DateTimeKind.Local).AddTicks(4458), new DateTime(2022, 4, 13, 21, 59, 56, 325, DateTimeKind.Local).AddTicks(537) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 4, 13, 21, 55, 7, 525, DateTimeKind.Local).AddTicks(3769), new DateTime(2022, 4, 13, 21, 55, 7, 526, DateTimeKind.Local).AddTicks(5473) });
        }
    }
}
