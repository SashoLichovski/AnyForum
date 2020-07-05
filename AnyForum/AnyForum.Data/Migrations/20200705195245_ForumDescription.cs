using Microsoft.EntityFrameworkCore.Migrations;

namespace AnyForum.Data.Migrations
{
    public partial class ForumDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Forums",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Forums");
        }
    }
}
