using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class newEntities_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 5, 43, 56, 622, DateTimeKind.Local).AddTicks(8991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 11, 5, 37, 28, 405, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "aa8d12e8-41f6-438a-ac9e-cb2c210834c8", "Admin", null },
                    { 2, "2c4f6beb-977a-412b-8f27-79c2cf5c2cc8", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sample Project 1" },
                    { 2, "Sample Project 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "500333fb-266a-41ca-b257-65108a26acd3", "user@teszt.com", false, false, null, "USER@TESZT.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "4bd51bb8-236c-453a-a7e3-eab64c50495a", false, "Teszt Elek" },
                    { 2, 0, "f1802d88-a476-4ede-925e-68289f3bd0c5", "bela@pelda.com", false, false, null, "BELA@PELDA.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "ddf779a0-d003-466f-b13c-74eccd4a47f9", false, "Példa Béla" },
                    { 3, 0, "a134b48b-abb7-4d50-8a69-0bf80dc14380", "admin@teszt.com", false, false, null, "ADMIN@TESZT.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "5a99aaad-16f5-4712-9788-a09e69de040b", false, "Teszt Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "DueDate", "EstimatedHours", "ProjectId", "StartDate", "Subject" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Issue 1" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Issue 2" }
                });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "IssueId", "Minutes", "UserId" },
                values: new object[] { 1, new DateTime(2021, 3, 11, 5, 43, 56, 648, DateTimeKind.Local).AddTicks(9259), "Write specification", 1, 120, 1 });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "IssueId", "Minutes", "UserId" },
                values: new object[] { 2, new DateTime(2021, 3, 11, 5, 43, 56, 649, DateTimeKind.Local).AddTicks(6183), "init project, base navigation system", 1, 300, 1 });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "IssueId", "Minutes", "UserId" },
                values: new object[] { 3, new DateTime(2021, 3, 11, 5, 43, 56, 649, DateTimeKind.Local).AddTicks(6403), "API research", 2, 600, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 5, 37, 28, 405, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 11, 5, 43, 56, 622, DateTimeKind.Local).AddTicks(8991));
        }
    }
}
