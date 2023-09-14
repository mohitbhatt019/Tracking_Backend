using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class changesInInvitetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "UserWhoInvited",
                table: "invitedUsers");

            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "invitedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InvitationReceiverUserId",
                table: "invitedUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvitationSenderUserId",
                table: "invitedUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "invitedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invitedUsers_InvitationReceiverUserId",
                table: "invitedUsers",
                column: "InvitationReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_invitedUsers_InvitationSenderUserId",
                table: "invitedUsers",
                column: "InvitationSenderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_invitedUsers_AspNetUsers_InvitationReceiverUserId",
                table: "invitedUsers",
                column: "InvitationReceiverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invitedUsers_AspNetUsers_InvitationSenderUserId",
                table: "invitedUsers",
                column: "InvitationSenderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitedUsers_AspNetUsers_InvitationReceiverUserId",
                table: "invitedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_invitedUsers_AspNetUsers_InvitationSenderUserId",
                table: "invitedUsers");

            migrationBuilder.DropIndex(
                name: "IX_invitedUsers_InvitationReceiverUserId",
                table: "invitedUsers");

            migrationBuilder.DropIndex(
                name: "IX_invitedUsers_InvitationSenderUserId",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "InvitationReceiverUserId",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "InvitationSenderUserId",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "invitedUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "invitedUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserWhoInvited",
                table: "invitedUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
