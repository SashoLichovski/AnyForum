using Microsoft.EntityFrameworkCore.Migrations;

namespace AnyForum.Data.Migrations
{
    public partial class IsApprovedForum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Forums",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Forums",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Forums");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Forums",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
