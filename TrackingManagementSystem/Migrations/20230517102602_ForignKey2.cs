using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    public partial class ForignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "trackers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_ApplicationUserId",
                table: "trackers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trackers_AspNetUsers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_ApplicationUserId",
                table: "trackers");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "trackers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
