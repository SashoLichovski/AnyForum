using Microsoft.EntityFrameworkCore.Migrations;

namespace AnyForum.Data.Migrations
{
    public partial class ForumUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Forums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Forums",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_UserId",
                table: "Forums",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_UserId",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Forums");
        }
    }
}
