using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CustomizeTrackingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trackers",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "ChangedBy",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "PreviousAddress",
                table: "trackers");

            migrationBuilder.RenameColumn(
                name: "PreviousName",
                table: "trackers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PreviousEmployeeCount",
                table: "trackers",
                newName: "DataChangeUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TrackingId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataChangeApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrackingDate",
                table: "trackers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_trackers",
                table: "trackers",
                column: "TrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_DataChangeApplicationUserId",
                table: "trackers",
                column: "DataChangeApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeApplicationUserId",
                table: "trackers",
                column: "DataChangeApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trackers",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "TrackingId",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "TrackingDate",
                table: "trackers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "trackers",
                newName: "PreviousName");

            migrationBuilder.RenameColumn(
                name: "DataChangeUserId",
                table: "trackers",
                newName: "PreviousEmployeeCount");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "trackers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ChangedBy",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreviousAddress",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trackers",
                table: "trackers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
