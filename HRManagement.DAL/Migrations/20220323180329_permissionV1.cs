using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class permissionV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 3, 29, 315, DateTimeKind.Local).AddTicks(358), new DateTime(2022, 3, 23, 21, 3, 29, 316, DateTimeKind.Local).AddTicks(9002) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BirthDay", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 23, 20, 51, 58, 299, DateTimeKind.Local).AddTicks(442), new DateTime(2022, 3, 23, 20, 51, 58, 300, DateTimeKind.Local).AddTicks(2554) });
        }
    }
}
