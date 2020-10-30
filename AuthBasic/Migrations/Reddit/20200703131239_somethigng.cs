using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthBasic.Migrations.Reddit
{
    public partial class somethigng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "post_id",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "createdString",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parentID",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "postID",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdString",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "parentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "postID",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "parent_id",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "post_id",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
