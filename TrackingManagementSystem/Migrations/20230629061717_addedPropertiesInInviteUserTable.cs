using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedPropertiesInInviteUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvitationReceiverUserName",
                table: "invitedUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvitationSenderUserName",
                table: "invitedUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitationReceiverUserName",
                table: "invitedUsers");

            migrationBuilder.DropColumn(
                name: "InvitationSenderUserName",
                table: "invitedUsers");
        }
    }
}
