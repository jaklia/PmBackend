using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class newEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "TimeEntries");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeEntries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 5, 37, 28, 405, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 27, 2, 37, 12, 125, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "TimeEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leave_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MeetingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeeting_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeeting_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 20, "R11" },
                    { 2, 50, "R22" },
                    { 3, 100, "C111" },
                    { 4, 20, "M44" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leave_UserId",
                table: "Leave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_RoomId",
                table: "Meeting",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_MeetingId",
                table: "UserMeeting",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_UserId",
                table: "UserMeeting",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "UserMeeting");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "TimeEntries");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeEntries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 27, 2, 37, 12, 125, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 11, 5, 37, 28, 405, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "TimeEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d7243e38-86e9-4547-b75d-0788206bad22", "Admin", null },
                    { 2, "272b5eef-60cc-491c-915f-5d596eab1c94", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sample Project 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "4f777eb8-4871-4b5f-99d8-c70788ec0cf0", "user@teszt.com", false, false, null, "USER@TESZT.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "ba9c8bfc-67cf-4cff-a90f-08a2c5c6c5be", false, "Teszt Elek" },
                    { 2, 0, "09881372-d2e8-48d4-bf10-2dc59ebae967", "bela@pelda.com", false, false, null, "BELA@PELDA.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "31276396-f88f-4fa1-a46b-4b385d720922", false, "Példa Béla" },
                    { 3, 0, "38d48d53-a566-47eb-9f4d-49f023cd5d1f", "admin@teszt.com", false, false, null, "ADMIN@TESZT.COM", null, "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA==", null, false, "91700818-1914-46cd-9c04-aa90bdfffd87", false, "Teszt Admin" }
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
                columns: new[] { "Id", "Date", "Description", "Hours", "IssueId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 2, 27, 2, 37, 12, 151, DateTimeKind.Local).AddTicks(7129), null, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "Hours", "IssueId", "UserId" },
                values: new object[] { 2, new DateTime(2021, 2, 27, 2, 37, 12, 152, DateTimeKind.Local).AddTicks(1046), null, 5, 1, 1 });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "Hours", "IssueId", "UserId" },
                values: new object[] { 3, new DateTime(2021, 2, 27, 2, 37, 12, 152, DateTimeKind.Local).AddTicks(1151), null, 10, 2, 2 });
        }
    }
}
