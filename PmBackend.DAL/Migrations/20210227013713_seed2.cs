using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 27, 2, 37, 12, 125, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 27, 1, 57, 50, 107, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d7243e38-86e9-4547-b75d-0788206bad22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "272b5eef-60cc-491c-915f-5d596eab1c94");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 27, 2, 37, 12, 151, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 27, 2, 37, 12, 152, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 2, 27, 2, 37, 12, 152, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f777eb8-4871-4b5f-99d8-c70788ec0cf0", "user@teszt.com", "USER@TESZT.COM", "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", "ba9c8bfc-67cf-4cff-a90f-08a2c5c6c5be" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09881372-d2e8-48d4-bf10-2dc59ebae967", "BELA@PELDA.COM", "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", "31276396-f88f-4fa1-a46b-4b385d720922" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38d48d53-a566-47eb-9f4d-49f023cd5d1f", "ADMIN@TESZT.COM", "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", "91700818-1914-46cd-9c04-aa90bdfffd87" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 27, 1, 57, 50, 107, DateTimeKind.Local).AddTicks(818),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 2, 27, 2, 37, 12, 125, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d228f074-3895-46c0-8610-0755d1530a3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "22f25cf7-34de-44ba-a9bd-cf4ae5e1330d");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 27, 1, 57, 50, 131, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 27, 1, 57, 50, 131, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 2, 27, 1, 57, 50, 131, DateTimeKind.Local).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e1cd89f-396b-4355-a294-6a78d5a741a4", "elek@teszt.com", null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6453dcb1-481c-43d5-8433-d9b95c97c00e", null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f96cf082-de71-4956-976d-021767fa0305", null, null, null });
        }
    }
}
