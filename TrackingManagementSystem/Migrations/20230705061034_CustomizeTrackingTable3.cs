using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CustomizeTrackingTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropColumn(
                name: "DataChangeApplicationUserId",
                table: "trackers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DataChangeUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_DataChangeUserId",
                table: "trackers");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_UserId",
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
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DataChangeUserId",
                table: "trackers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataChangeApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trackers_ApplicationUserId",
                table: "trackers",
                column: "ApplicationUserId");

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
    }
}
