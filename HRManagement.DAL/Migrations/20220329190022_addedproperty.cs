using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.DAL.Migrations
{
    public partial class addedproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDaysOff",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Address", "BirthDay", "Email", "PhoneNumber", "StartDate" },
                values: new object[] { "Ayrancı mahallesi Gül sokak Kat:3 No:11 Maltepe/İstanbul", new DateTime(2022, 3, 29, 22, 0, 21, 94, DateTimeKind.Local).AddTicks(1591), "inci.adiyaman@hrmanagement.com", "05551234567", new DateTime(2022, 3, 29, 22, 0, 21, 95, DateTimeKind.Local).AddTicks(7145) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDaysOff",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Address", "BirthDay", "Email", "PhoneNumber", "StartDate" },
                values: new object[] { "İstanbul", new DateTime(2022, 3, 23, 21, 3, 29, 315, DateTimeKind.Local).AddTicks(358), "inci.adiyaman@hotmail.com", "055555555", new DateTime(2022, 3, 23, 21, 3, 29, 316, DateTimeKind.Local).AddTicks(9002) });
        }
    }
}
