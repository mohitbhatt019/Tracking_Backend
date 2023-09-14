using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeUserId",
                table: "trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_UserId",
                table: "trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_companies_CompanyId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_CompanyId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_DataChangeUserId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_UserId",
                table: "trackers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrackingDate",
                table: "trackers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DataChangeUserId",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "trackers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DataChangeUserIdName",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdName",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataChangeUserIdName",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "UserIdName",
                table: "trackers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrackingDate",
                table: "trackers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataChangeUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "trackers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trackers_CompanyId",
                table: "trackers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_DataChangeUserId",
                table: "trackers",
                column: "DataChangeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_UserId",
                table: "trackers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeUserId",
                table: "trackers",
                column: "DataChangeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_UserId",
                table: "trackers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_companies_CompanyId",
                table: "trackers",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
