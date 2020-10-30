using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthBasic.Migrations.Reddit
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "unixTimestamp",
                table: "Comments",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "score",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "unixTimestamp",
                table: "Comments");
        }
    }
}
