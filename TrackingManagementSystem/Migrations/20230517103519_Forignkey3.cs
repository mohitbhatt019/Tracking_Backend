using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    public partial class Forignkey3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvitedUserId",
                table: "companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "invitedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invitedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invitedUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_InvitedUserId",
                table: "companies",
                column: "InvitedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_invitedUsers_ApplicationUserId",
                table: "invitedUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_invitedUsers_InvitedUserId",
                table: "companies",
                column: "InvitedUserId",
                principalTable: "invitedUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_invitedUsers_InvitedUserId",
                table: "companies");

            migrationBuilder.DropTable(
                name: "invitedUsers");

            migrationBuilder.DropIndex(
                name: "IX_companies_InvitedUserId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "InvitedUserId",
                table: "companies");
        }
    }
}
