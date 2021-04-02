using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class meeting_title_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 2, 1, 11, 52, 325, DateTimeKind.Local).AddTicks(7208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 25, 13, 34, 4, 232, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Meeting",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "61d4f7c8-df87-4954-b97e-7170bbe796bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "655fcc8c-f11c-43b8-8b09-3268f87066c7");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 4, 2, 1, 11, 52, 349, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 4, 2, 1, 11, 52, 349, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 4, 2, 1, 11, 52, 349, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67d67d5b-0750-4f67-acf9-e2eb97e3a8dd", "8d098873-c906-44f3-b4c6-51940e8d044e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5de07873-c692-4d7c-9f70-3ab0fa9be2d7", "eab7aa63-aaba-4f20-8d23-34333842ca7f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24d4227a-30e5-4482-9662-7d6e58c70f9d", "5a7f6774-3e93-41c0-bb50-0214e582405a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Meeting");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 25, 13, 34, 4, 232, DateTimeKind.Local).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 2, 1, 11, 52, 325, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "442ec3ff-276e-4c4e-b713-b743b3f95c6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3a608af4-4982-49be-b221-fe064a7bd552");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 25, 13, 34, 4, 250, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 3, 25, 13, 34, 4, 251, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 3, 25, 13, 34, 4, 251, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38e3dad2-1d9c-4eb4-9def-f46e7329ffb5", "159c0da0-a2db-4910-b62d-2c02a49344b9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0f44a7f-c64c-4ffb-8481-21612b63c333", "efae110a-d2ed-4200-bba5-b14b62d155f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a051930c-f6d5-46b7-9cda-1d263806ad64", "4b27aa71-844e-4247-9d6a-d2c37a2e4ef1" });
        }
    }
}
