using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 23, 22, 13, 27, 56, DateTimeKind.Local).AddTicks(3363),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 23, 0, 31, 21, 189, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "Hours", "IssueId" },
                values: new object[] { 3, new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(5509), null, 10, 2 });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "Hours", "IssueId" },
                values: new object[] { 2, new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(5429), null, 5, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 23, 0, 31, 21, 189, DateTimeKind.Local).AddTicks(6088),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 23, 22, 13, 27, 56, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 23, 0, 31, 21, 225, DateTimeKind.Local).AddTicks(4682));
        }
    }
}
