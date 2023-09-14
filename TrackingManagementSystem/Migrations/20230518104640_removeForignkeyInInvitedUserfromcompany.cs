using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class removeForignkeyInInvitedUserfromcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_invitedUsers_InvitedUserId",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "IX_companies_InvitedUserId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "InvitedUserId",
                table: "companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvitedUserId",
                table: "companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_companies_InvitedUserId",
                table: "companies",
                column: "InvitedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_invitedUsers_InvitedUserId",
                table: "companies",
                column: "InvitedUserId",
                principalTable: "invitedUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
