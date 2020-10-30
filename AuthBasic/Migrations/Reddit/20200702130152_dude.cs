using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthBasic.Migrations.Reddit
{
    public partial class dude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    parent_id = table.Column<string>(nullable: true),
                    post_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
