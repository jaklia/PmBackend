using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PmBackend.DAL.Migrations
{
    public partial class table_names_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_Users_UserId",
                table: "Leave");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Room_RoomId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeeting_Meeting_MeetingId",
                table: "UserMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeeting_Users_UserId",
                table: "UserMeeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMeeting",
                table: "UserMeeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leave",
                table: "Leave");

            migrationBuilder.RenameTable(
                name: "UserMeeting",
                newName: "UserMeetings");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.RenameTable(
                name: "Leave",
                newName: "Leaves");

            migrationBuilder.RenameIndex(
                name: "IX_UserMeeting_UserId",
                table: "UserMeetings",
                newName: "IX_UserMeetings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMeeting_MeetingId",
                table: "UserMeetings",
                newName: "IX_UserMeetings_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_RoomId",
                table: "Meetings",
                newName: "IX_Meetings_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Leave_UserId",
                table: "Leaves",
                newName: "IX_Leaves_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 2, 4, 42, 22, 19, DateTimeKind.Local).AddTicks(7881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 2, 1, 11, 52, 325, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMeetings",
                table: "UserMeetings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaves",
                table: "Leaves",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5296e506-9091-40a3-8989-1ec1c16a796e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1e0e9ae6-adfd-4952-8016-7d5bcfc550d1");

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 4, 2, 4, 42, 22, 41, DateTimeKind.Local).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 4, 2, 4, 42, 22, 42, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "TimeEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 4, 2, 4, 42, 22, 42, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96fa8feb-58be-4881-a30e-570d57f150cb", "2a88ea9b-9f71-4c51-8dc2-a62ec1c6c7c9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fc761afd-6eac-476b-9a24-06be27def2f5", "e902148b-6326-425b-aa57-2dccf6ab88ae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dcefe3f3-0813-4c9f-ab4d-1b9ed39cde69", "f715d865-23f5-4bc5-9e4c-ac718de41549" });

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_Users_UserId",
                table: "Leaves",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Rooms_RoomId",
                table: "Meetings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeetings_Meetings_MeetingId",
                table: "UserMeetings",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeetings_Users_UserId",
                table: "UserMeetings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_Users_UserId",
                table: "Leaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Rooms_RoomId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeetings_Meetings_MeetingId",
                table: "UserMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeetings_Users_UserId",
                table: "UserMeetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMeetings",
                table: "UserMeetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaves",
                table: "Leaves");

            migrationBuilder.RenameTable(
                name: "UserMeetings",
                newName: "UserMeeting");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.RenameTable(
                name: "Leaves",
                newName: "Leave");

            migrationBuilder.RenameIndex(
                name: "IX_UserMeetings_UserId",
                table: "UserMeeting",
                newName: "IX_UserMeeting_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMeetings_MeetingId",
                table: "UserMeeting",
                newName: "IX_UserMeeting_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_RoomId",
                table: "Meeting",
                newName: "IX_Meeting_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Leaves_UserId",
                table: "Leave",
                newName: "IX_Leave_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 2, 1, 11, 52, 325, DateTimeKind.Local).AddTicks(7208),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 2, 4, 42, 22, 19, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMeeting",
                table: "UserMeeting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leave",
                table: "Leave",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_Users_UserId",
                table: "Leave",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Room_RoomId",
                table: "Meeting",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeeting_Meeting_MeetingId",
                table: "UserMeeting",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeeting_Users_UserId",
                table: "UserMeeting",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
