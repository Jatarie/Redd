using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthBasic.Migrations.Reddit
{
    public partial class whatnothinga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "body",
                table: "Posts");
        }
    }
}
