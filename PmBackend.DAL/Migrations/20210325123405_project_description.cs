using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class project_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 25, 13, 34, 4, 232, DateTimeKind.Local).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 11, 5, 43, 56, 622, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 5, 43, 56, 622, DateTimeKind.Local).AddTicks(8991),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 25, 13, 34, 4, 232, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "aa8d12e8-41f6-438a-ac9e-cb2c210834c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2c4f6beb-977a-412b-8f27-79c2cf5c2cc8");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 11, 5, 43, 56, 648, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 3, 11, 5, 43, 56, 649, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 3, 11, 5, 43, 56, 649, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "500333fb-266a-41ca-b257-65108a26acd3", "4bd51bb8-236c-453a-a7e3-eab64c50495a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1802d88-a476-4ede-925e-68289f3bd0c5", "ddf779a0-d003-466f-b13c-74eccd4a47f9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a134b48b-abb7-4d50-8a69-0bf80dc14380", "5a99aaad-16f5-4712-9788-a09e69de040b" });
        }
    }
}
