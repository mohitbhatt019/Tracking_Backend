using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingManagementSystem.Migrations
{
    public partial class Forignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "trackers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "companies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_CompanyId",
                table: "trackers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_companies_ApplicationUserId",
                table: "companies",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_AspNetUsers_ApplicationUserId",
                table: "companies",
                column: "ApplicationUserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_AspNetUsers_ApplicationUserId",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_trackers_companies_CompanyId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_trackers_CompanyId",
                table: "trackers");

            migrationBuilder.DropIndex(
                name: "IX_companies_ApplicationUserId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "trackers");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
