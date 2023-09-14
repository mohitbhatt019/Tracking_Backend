using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class removeForignkeyInInvitedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitedUsers_AspNetUsers_ApplicationUserId",
                table: "invitedUsers");

            migrationBuilder.DropIndex(
                name: "IX_invitedUsers_ApplicationUserId",
                table: "invitedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "invitedUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "invitedUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_invitedUsers_ApplicationUserId",
                table: "invitedUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_invitedUsers_AspNetUsers_ApplicationUserId",
                table: "invitedUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
